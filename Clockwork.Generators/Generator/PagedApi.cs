using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

#nullable enable

namespace Clockwork.Models
{
    
    [Generator]
    public class ApiGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context){
        Compilation compilation = context.Compilation;

        IEnumerable<SyntaxNode>? allNodes = compilation.SyntaxTrees.SelectMany(s => s.GetRoot().DescendantNodes());
        IEnumerable<AttributeSyntax> allAttributes = allNodes.Where((d) => d.IsKind(SyntaxKind.Attribute)).OfType<AttributeSyntax>();
        IEnumerable<ClassDeclarationSyntax> allClasses = allNodes.Where((d) => d.IsKind(SyntaxKind.ClassDeclaration)).OfType<ClassDeclarationSyntax>();
        ImmutableArray<AttributeSyntax> filterAttributes = allAttributes.Where(d => d.Name.ToString() == "Filter")
            .ToImmutableArray();
        ImmutableArray<AttributeSyntax> attributes = allAttributes.Where(d => d.Name.ToString() == "Api")
            .ToImmutableArray();

        var apiClasses = allClasses.Where(e => e.AttributeLists.Any(e => e.Attributes.Any(d=> (d.Name as SimpleNameSyntax)?.Identifier.Text.Equals("Api") ?? false )));



        var index = 0;
        foreach(var t in apiClasses){
            index += 1;


                //var nodes = tree.GetRoot().DescendantNodes();
                //var sm = compilation.GetSemanticModel(tree);
                //var f = nodes.OfType<PropertyDeclarationSyntax>().FirstOrDefault();
                //var n = nodes.OfType<TypeDeclarationSyntax>().FirstOrDefault();
                var name = t.Identifier.ValueText;
                //var v = t.AttributeLists.SelectMany(e => e.Attributes).Where( d=> (d.Name as SimpleNameSyntax)?.Identifier.Text.Equals("Api") ?? false ).FirstOrDefault();
                //var names = name+"s";
                var sm = compilation.GetSemanticModel(t.SyntaxTree);
                var cl = sm.GetDeclaredSymbol(t) as ITypeSymbol;
                var names = cl?.GetAttributes().SelectMany(e=> e.NamedArguments).FirstOrDefault(na => na.Key == "Plural").Value.Value?.ToString();
                var s = t.SyntaxTree.GetRoot().DescendantNodes().OfType<PropertyDeclarationSyntax>().FirstOrDefault( e => e.Identifier.ValueText.Equals("DbSetName"));
                names ??=  name + "s";
                
                //var sm.GetDeclaredSymbol()
                /*if (f != null){
                    name = sm.GetDeclaredSymbol(f)?.ContainingType?.Name?.ToString();
                }*/
                var rb = "}";
                var lb = "{";

                StringBuilder sourceBuilder = new StringBuilder($@"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clockwork.Models;
using tephraAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace tephraApi.Controllers");
                sourceBuilder.AppendLine(@"{");
                sourceBuilder.AppendLine($@"
    [Route(""api/[controller]"")]
    [ApiController]
    public class {name}Controller : ControllerBase");
                sourceBuilder.AppendLine("\t{");
                sourceBuilder.AppendLine($@"
        private readonly BaseDbContext _context;

        public {name}Controller(BaseDbContext context)
                ");
                sourceBuilder.AppendLine("\t\t{");
                sourceBuilder.AppendLine(@"
            _context = context;
                ");
                sourceBuilder.AppendLine("\t\t}");
                sourceBuilder.AppendLine(@"
        [HttpGet(""count"")]
        [EnableCors(""Permissive"")]
        public async Task<ActionResult<int>> GetCount()
                ");
                sourceBuilder.AppendLine("\t\t{");
        {
                sourceBuilder.AppendLine($@"
            return await _context.{names}.CountAsync();
                ");
                sourceBuilder.AppendLine("\t\t}");
        }



                sourceBuilder.AppendLine($@"
        [HttpGet]
        [EnableCors(""Permissive"")]
        public async Task<ActionResult<IEnumerable<{name}>>> Get{names}()
                ");
                sourceBuilder.AppendLine("\t\t{");
                sourceBuilder.AppendLine($@"
            return await _context.{names}.ToListAsync();
                ");
                sourceBuilder.AppendLine("\t\t}");
                sourceBuilder.AppendLine(@"
        [HttpGet(""{page}/{page_size}"")]
        [EnableCors(""Permissive"")]
        ");
                sourceBuilder.AppendLine($@"
        public async Task<ActionResult<IEnumerable<{name}>>> Get{names}(int page, int page_size)
                ");
                sourceBuilder.AppendLine("\t\t{");
                sourceBuilder.AppendLine($@"
            var p = page-1;
            return await _context.{names}.Skip(p*page_size).Take(page_size).ToListAsync();
            ");
                sourceBuilder.AppendLine("\t\t}");

                sourceBuilder.AppendLine(@"
        [HttpGet(""{id}"")]
        [EnableCors(""Permissive"")]
        ");
                sourceBuilder.AppendLine($@"
        public async Task<ActionResult<{name}>> Get{name}(int id)
        ");
                sourceBuilder.AppendLine("\t\t{");
                sourceBuilder.AppendLine($@"
            var obj = await _context.{names}.FindAsync(id);

            if (obj == null) return NotFound();

            return obj;
            ");
                sourceBuilder.AppendLine("\t\t}");

                sourceBuilder.AppendLine(@"
        [HttpPut(""{id}"")]
        [EnableCors(""Permissive"")]
        ");
                sourceBuilder.AppendLine($@"
        public async Task<IActionResult> Put{name}(int id, {name} obj)
        ");
                sourceBuilder.AppendLine("\t\t{");
                sourceBuilder.AppendLine($@"
            if (id != obj.Id) return BadRequest();

            _context.Entry(obj).State = EntityState.Modified;

            try
                ");
                sourceBuilder.AppendLine("\t\t\t{");
                sourceBuilder.AppendLine($@"
                await _context.SaveChangesAsync();
                ");
                sourceBuilder.AppendLine("\t\t\t}");
                sourceBuilder.AppendLine($@"
            catch (DbUpdateConcurrencyException)
                ");
                sourceBuilder.AppendLine("\t\t\t{");
                sourceBuilder.AppendLine($@"
                if (!{name}Exists(id)) return NotFound();
                else throw;
                ");
                sourceBuilder.AppendLine("\t\t\t}");

            sourceBuilder.AppendLine($@"
            return NoContent();
            ");
        sourceBuilder.AppendLine("\t\t}");


                sourceBuilder.AppendLine($@"
        [HttpPost]
        [EnableCors(""Permissive"")]
        public async Task<ActionResult<{name}>> Post{name}({name} obj)
            ");
        sourceBuilder.AppendLine("\t\t{");
                sourceBuilder.AppendLine($@"
            _context.{names}.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction(""Get{name}"", new {lb} id = obj.Id {rb}, obj);
            ");
        sourceBuilder.AppendLine("\t\t}");


                sourceBuilder.AppendLine(@"
        [HttpDelete(""{id}"")]
            ");
                sourceBuilder.AppendLine($@"
        public async Task<IActionResult> Delete{name}(int id)
            ");
        sourceBuilder.AppendLine("\t\t{");
                sourceBuilder.AppendLine($@"
            var obj = await _context.{names}.FindAsync(id);
            if (obj == null) return NotFound();


            _context.{names}.Remove(obj);
            await _context.SaveChangesAsync();

            return NoContent();
            ");
        sourceBuilder.AppendLine("\t\t}");

                sourceBuilder.AppendLine($@"
        [HttpDelete]
        public async Task<IActionResult> DeleteAll{names}()
            ");
        sourceBuilder.AppendLine("\t\t{");
                sourceBuilder.AppendLine($@"
            _context.{names}.RemoveRange(_context.{names});
            await _context.SaveChangesAsync();

            return NoContent();
            ");
        sourceBuilder.AppendLine("\t\t}");

                sourceBuilder.AppendLine($@"
        private bool {name}Exists(int id)
            ");
        sourceBuilder.AppendLine("\t\t{");
                sourceBuilder.AppendLine($@"
            return _context.{names}.Any(e => e.Id == id);
            ");
        sourceBuilder.AppendLine("\t\t}");
    sourceBuilder.AppendLine("\t}");
sourceBuilder.AppendLine("}");

                var source = sourceBuilder.ToString();

                context.AddSource($"{name}", SourceText.From(source, Encoding.UTF8));
            }
        }
        public void Initialize(GeneratorInitializationContext context)
        {
        }            
    }
    [Generator]
    public class TestGenerator : ISourceGenerator
    {

        public void Execute(GeneratorExecutionContext context)
        {

            Compilation compilation = context.Compilation;

            IEnumerable<SyntaxNode>? allNodes = compilation.SyntaxTrees.SelectMany(s => s.GetRoot().DescendantNodes());
            IEnumerable<AttributeSyntax> allAttributes = allNodes.Where((d) => d.IsKind(SyntaxKind.Attribute)).OfType<AttributeSyntax>();
            ImmutableArray<AttributeSyntax> filterAttributes = allAttributes.Where(d => d.Name.ToString() == "Filter")
                .ToImmutableArray();
            ImmutableArray<SyntaxTree> apiAttributes = allAttributes.Where(d => d.Name.ToString() == "Api").Select(d => d.SyntaxTree)
                .ToImmutableArray();

                 StringBuilder sourceBuilder = new StringBuilder(@"
using System;
namespace Test
{
    public static class Test
    {
        public static void Read() 
        {
            Console.WriteLine(""The following semanticmodels contained the api attribute :"");
");
            var index = 0;
            foreach (SyntaxTree tree in apiAttributes)
            {
                index += 1;
                sourceBuilder.AppendLine($"//{index}");
                var nodes = tree.GetRoot().DescendantNodes();
                var sm = compilation.GetSemanticModel(tree);
                var fields = nodes.OfType<PropertyDeclarationSyntax>();
                var n = nodes.OfType<TypeDeclarationSyntax>().FirstOrDefault();
                var name = "";
                if (n != null){
                    name = sm.GetDeclaredSymbol(n)?.ContainingType?.ToString();
                    //sourceBuilder.AppendLine($@"Console.WriteLine(@"" - Class : {name}"");");
                }
                foreach (var f in fields){
                    var t = sm.GetDeclaredSymbol(f);
                    sourceBuilder.AppendLine($@"Console.WriteLine(@"" - {t?.ToString()}"");");
                }
            }

            // finish creating the source to inject
            sourceBuilder.Append(@"
        }
    }
}");  
            var source = sourceBuilder.ToString();
            var hintName = "test";

            context.AddSource(hintName, SourceText.From(source, Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }
    }
    [Generator]
    public class HelloWorldGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            // begin creating the source we'll inject into the users compilation
            StringBuilder sourceBuilder = new StringBuilder(@"
using System;
namespace HelloWorldGenerated
{
    public static class HelloWorld
    {
        public static void SayHello() 
        {
            Console.WriteLine(""Hello from generated code!"");
            Console.WriteLine(""The following syntax trees existed in the compilation that created this program:"");
");

            // using the context, get a list of syntax trees in the users compilation
            IEnumerable<SyntaxTree> syntaxTrees = context.Compilation.SyntaxTrees;

            // add the filepath of each tree to the class we're building
            foreach (SyntaxTree tree in syntaxTrees)
            {
                sourceBuilder.AppendLine($@"Console.WriteLine(@"" - {tree.FilePath}"");");
            }

            // finish creating the source to inject
            sourceBuilder.Append(@"
        }
    }
}");

            // inject the created source into the users compilation
            context.AddSource("helloWorldGenerated", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            // No initialization required
        }
    }
    internal static class Helpers {

        internal static SimpleNameSyntax? GetSimpleNameFromNode(AttributeSyntax node)
        {
            var identifierNameSyntax = node.Name as IdentifierNameSyntax;
            var qualifiedNameSyntax = node.Name as QualifiedNameSyntax;
            
            return
                identifierNameSyntax
                ??
                qualifiedNameSyntax?.Right
                ??
                (node.Name as AliasQualifiedNameSyntax)?.Name;
        }
    }
}
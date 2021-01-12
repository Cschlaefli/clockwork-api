using Clockwork.Models;

namespace Clockwork.API.GenerationModels{

    [Api]
    public class Augment : Clockwork.Models.Augment {
    }

    [Api(Plural = "Specialties")]
    public class Specialty : Clockwork.Models.Specialty {
    }
}
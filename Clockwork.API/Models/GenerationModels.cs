using Clockwork.Models;

namespace tephraAPI.GenerationModels{

    [Api]
    public class Augment : Clockwork.Models.Augment {
    }

    [Api(Plural = "Specialties")]
    public class Specialty : Clockwork.Models.Specialty {
    }
}
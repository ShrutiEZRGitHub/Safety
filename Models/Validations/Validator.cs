using FluentValidation;

namespace Models.Validations;

//public class APSEZITValidator : AbstractValidator<APSEZITSurvey>
//{
//    public APSEZITValidator()
//    {
//        RuleFor(y => y.perfOfITInfra).InclusiveBetween(1, 5).WithMessage("Please select Overall Performance of IT Infrastructure");
//        RuleFor(y => y.perfOfITApps).InclusiveBetween(1, 5).WithMessage("Please Select Overall Performance of IT Applications");
//        RuleFor(y => y.perfOfITIncRespAndResTime).InclusiveBetween(1, 5).WithMessage("Please Select Overall Performance of IT Incidence Response and Resolution Time Between");
//        RuleFor(y => y.appServNeedImmdImpr).NotEmpty().WithMessage("Please enter Any Application/Service you want Immediate Improvement to");
//        RuleFor(y => y.overallComment).NotEmpty().WithMessage("Please enter Overall Comments & Feedback");
//    }
//}
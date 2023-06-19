
using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation
{
    public class ValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        {
            var contex = new ValidationContext<Object>(entity);
            var result= validator.Validate(contex);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

        } 
    }
}

using System.Collections.Generic;

namespace Arquitetura_Curso_DIO.Models.Responses
{
    public class BadRequestResponse
    {
        public IEnumerable<BadRequestField> ErrorFieldList { get; }

        public BadRequestResponse(IEnumerable<BadRequestField> errorList)
        {
            ErrorFieldList = errorList;
        }
    }

    public class BadRequestField
    {
        public string FieldName { get; }
        public IEnumerable<string> FieldErrorMessages { get; }

        public BadRequestField(string fieldName, IEnumerable<string> fieldErrorMessages)
        {
            FieldName = fieldName;
            FieldErrorMessages = fieldErrorMessages;
        }

        public BadRequestField(string fieldName, string fieldErrorMessage)
        {
            FieldName = fieldName;
            FieldErrorMessages = new List<string> { fieldErrorMessage };
        }
    }
}

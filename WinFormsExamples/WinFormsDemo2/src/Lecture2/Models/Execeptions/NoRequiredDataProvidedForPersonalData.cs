using System;

namespace Lecture2.Models.Execeptions
{
    public class NoRequiredDataProvidedForPersonalData:Exception
    {
        public PersonalDataEditorModel Model { get; }

        public NoRequiredDataProvidedForPersonalData(PersonalDataEditorModel model) : base(
            "No required data - firstName, lastName was provided. Cannot create personal data")
        {
            Model = model;
        }
    }
}

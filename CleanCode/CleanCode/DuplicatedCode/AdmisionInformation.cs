namespace CleanCode.DuplicatedCode
{
    public class AdmisionInformation
    {
        public AdmisionInformation(string admissionDateTime)
        {
            AdmissionDateTime = admissionDateTime;
        }

        public string AdmissionDateTime { get; private set; }
    }
}

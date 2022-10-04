namespace RateMyAnimal.Domain.Helpers
{
    public class Notification
    {
        public Notification(string message, string fieldname)
        {
            Message = message;
            FieldName = fieldname;
        }

        public string FieldName { get; }
        public string Message { get; }       
    }
}

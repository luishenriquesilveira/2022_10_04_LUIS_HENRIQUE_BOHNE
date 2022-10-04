using FluentValidation.Results;

namespace RateMyAnimal.Domain.Helpers
{
    public class Notificator
    {
        private List<Notification> _notification = new List<Notification>();

        public List<Notification> Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _notification.Add(new Notification(error.ErrorMessage, error.PropertyName));
            }

            return _notification;
        }
    }
}

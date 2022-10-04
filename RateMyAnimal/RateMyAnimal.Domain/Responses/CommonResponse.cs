using RateMyAnimal.Domain.Entities;
using RateMyAnimal.Domain.Helpers;

namespace RateMyAnimal.Domain.Responses
{
    public class CommonResponse<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<Notification> Notifications { get; set; }

        public static CommonResponse<T> Fail(string errorMessage)
        {
            return new CommonResponse<T> { Succeeded = false, Message = errorMessage };
        }

        public static CommonResponse<T> FailNotFound(int id)
        {
            return new CommonResponse<T> { Succeeded = false, Message = $"The resource with id {id} was not found." };
        }

        public static CommonResponse<T> FailEmpty()
        {
            return new CommonResponse<T> { Succeeded = false, Message = "The list is empty." };
        }

        public static CommonResponse<T> FailValidation(List<Notification> notifications)
        {
            return new CommonResponse<T> { Succeeded = false, Message = "An error occured while validating your model.", Notifications = notifications };
        }

        public static CommonResponse<T> Success(T data)
        {
            return new CommonResponse<T> { Succeeded = true, Data = data, Message = "" };
        }

        public static CommonResponse<Animal> Success(object value)
        {
            throw new NotImplementedException();
        }
    }
}

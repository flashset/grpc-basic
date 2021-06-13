using System;

namespace DataStore.DataModel
{
    [Serializable]
    public class RegisterRequestModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
    }

    [Serializable]
    public class RegisterResponseModel
    {
        public bool IsSuccess { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}

﻿namespace Presentation.Models
{
    public class CommonResponse
    {
        public DateTime ResponsedAt { get; set; } = DateTime.UtcNow;

        public bool IsSuccess { get; set; }

        public object Body { get; set; }

        public IEnumerable<string> ErrorMessages { get; set; }

        #region Static Methods
        public static CommonResponse Success(object body = null)
        {
            return new()
            {
                IsSuccess = true,
                Body = body
            };
        }
        public static CommonResponse Failed(IEnumerable<string> messages)
        {
            return new CommonResponse
            {
                IsSuccess = false,
                ErrorMessages = messages
            };
        }
        #endregion

        public const string DatabaseErrorMessage = "Something wrong with the database when processing.";
        public const string InvalidTokenMessage = "The provided token is invalid.";
    }
}

using System.Collections.Generic;

namespace ApiUsers.Helpers
{
    public class ResultHelper<T>
    {
        public T Value { get; set; }
        public List<string> Errors { get; set; }
        public ResultHelper()
        {
            this.Errors = new List<string>();
        }
        public void AddError(string error)
        {
            this.Errors.Add(error);
        }
        public bool Success
        {
            get { return (this.Errors.Count == 0); }
        }
    }
}

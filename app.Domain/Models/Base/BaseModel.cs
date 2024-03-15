namespace app.Domain.Models.Base
{
    public abstract class BaseModel
    {
        protected BaseModel() { }

        public long Id { get; set; }
    }
}
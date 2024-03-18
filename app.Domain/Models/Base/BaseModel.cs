﻿namespace app.Domain.Models.Base
{
    public abstract class BaseModel
    {
        protected BaseModel() { }

        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
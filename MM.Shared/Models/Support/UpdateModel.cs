﻿using System.ComponentModel.DataAnnotations;

namespace MM.Shared.Models.Support
{
    public class UpdateModel : ProtectedMainDocument
    {
        public UpdateModel() : base(DocumentType.Update)
        {
        }

        [Required]
        [Custom(Name = "Title", Placeholder = "...")]
        public string? Title { get; set; }

        [Required]
        [Custom(Name = "Description", Placeholder = "...")]
        public string? Description { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public void Initialize()
        {
            var id = Guid.NewGuid().ToString();

            base.Initialize(id);
        }

        public override bool HasValidData()
        {
            return Title.NotEmpty() && Description.NotEmpty();
        }

        public override bool Equals(object? obj)
        {
            return obj is UpdateModel q && q.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id?.GetHashCode() ?? 0;
        }
    }
}
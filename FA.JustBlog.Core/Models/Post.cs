﻿using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? PostContent { get; set; }
        public string? UrlSlug { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public bool Modified { get; set; }
        public int ViewCount { get; set; }
        public int RateCount { get; set; }
        public int TotalRate { get; set; }
        [NotMapped]
        public decimal Rate { get => RateCount == 0 ? 0m : TotalRate * 1.0m / RateCount; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<PostTagMap>? PostTagMaps { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<GalleryImage> GalleryImages { get; set; }
    }
}
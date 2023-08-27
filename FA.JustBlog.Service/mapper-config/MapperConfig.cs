using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModel.Categories;
using FA.JustBlog.ViewModel.Comments;
using FA.JustBlog.ViewModel.Posts;
using FA.JustBlog.ViewModel.Tags;

namespace FA.JustBlog.Service.mapper_config
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Comment, CommentModel>().ReverseMap();
            CreateMap<Post, PostModel>().ReverseMap();
            CreateMap<Tag, TagModel>().ReverseMap();
        }
    }
}

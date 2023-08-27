using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.ViewModel.Posts;
using FA.JustBlog.ViewModel.Responses;

namespace FA.JustBlog.Service.post
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public PostService(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public ResponseResult<PostModel> Create(PostModel model)
        {
            try
            {
                if (model == null)
                {
                    return new ResponseResult<PostModel>($"Create failed!");
                }
                if (string.IsNullOrWhiteSpace(model.Title))
                {
                    return new ResponseResult<PostModel>($"Create failed!");
                }
                if (model.Title.Length <= 5)
                {
                    return new ResponseResult<PostModel>($"Create failed!");
                }
                if (model.UrlSlug.Length <= 5)
                {
                    return new ResponseResult<PostModel>($"Create failed!");
                }

                var result = uow.PostRepository.Find(model.Id);
                if (result == null)
                {
                    return new ResponseResult<PostModel>($"Can't find the category that has id = {model.Id}");
                }

                model.Title = model.Title.Replace("<p>", "").Replace("</p>", "");
                var entity = mapper.Map<Post>(model);

                uow.PostRepository.Create(entity);
                uow.SaveChanges();

                return new ResponseResult<PostModel>() { Data = model, Message = "Create successed!" };

            }
            catch (Exception)
            {
                return new ResponseResult<PostModel>($"Create failed!");
            }
        }

        public ResponseResult<PostModel> Delete(Guid postId)
        {
            try
            {
                if (postId == Guid.Empty)
                {
                    return new ResponseResult<PostModel>($"Delete failed!");
                }

                var result = uow.PostRepository.Find(postId);
                if (result == null)
                {
                    return new ResponseResult<PostModel>($"Can't find the category that has id = {postId}");
                }

                uow.PostRepository.Delete(postId);
                uow.SaveChanges();

                return new ResponseResult<PostModel>() { Message = "Delete successed!" };

            }
            catch (Exception)
            {
                return new ResponseResult<PostModel>($"Delete failed!");
            }
        }

        public ResponseResult<PostModel> Edit(PostModel model)
        {
            throw new NotImplementedException();
        }

        public ResponseResult<PostModel> Find(Guid postId)
        {
            try
            {
                if (postId == Guid.Empty)
                {
                    return new ResponseResult<PostModel>($"Invalid PostId");
                }

                var result = uow.PostRepository.Find(postId);
                if (result == null)
                {
                    return new ResponseResult<PostModel>($"Can't find the category that has id = {postId}");
                }

                var model = mapper.Map<PostModel>(result);
                return new ResponseResult<PostModel> { Data = model, Message = "Find Successed!" };
            }
            catch (Exception)
            {
                return new ResponseResult<PostModel>($"Find failed!");
            }
        }

        public ResponseResult<PostModel> GetAll()
        {
            ResponseResult<PostModel> response = new ResponseResult<PostModel>();

            try
            {
                var posts = uow.PostRepository.GetAll();
                if (posts == null || posts.Count() == 0)
                {
                    return new ResponseResult<PostModel>() { Message = "No data", StatusCode = 404 };
                }
                var postModels = mapper.Map<List<PostModel>>(posts);
                return new ResponseResult<PostModel>() { DataList = postModels, Message = "Success" };
            }
            catch (Exception ex)
            {
                response.Message = "Loi 500 Server";
            }

            return response;
        }
    }
}

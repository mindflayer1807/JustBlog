using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.ViewModel.Posts;
using FA.JustBlog.ViewModel.Responses;
using FA.JustBlog.ViewModel.Tags;

namespace FA.JustBlog.Service.tag
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public TagService(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public ResponseResult<TagModel> Create(TagModel model)
        {
            try
            {
                if (model == null)
                {
                    return new ResponseResult<TagModel>($"Create failed!");
                }
                if (string.IsNullOrWhiteSpace(model.Name))
                {
                    return new ResponseResult<TagModel>($"Create failed!");
                }
                if (model.Name.Length <= 5)
                {
                    return new ResponseResult<TagModel>($"Create failed!");
                }
                if (model.UrlSlug.Length <= 5)
                {
                    return new ResponseResult<TagModel>($"Create failed!");
                }
                if (model.Description.Length <= 5)
                {
                    return new ResponseResult<TagModel>($"Create failed!");
                }

                var result = uow.TagRepository.Find(model.Id);
                if (result == null)
                {
                    return new ResponseResult<TagModel>($"Can't find the category that has id = {model.Id}");
                }

                model.Description = model.Description.Replace("<p>", "").Replace("</p>", "");
                var entity = mapper.Map<Tag>(model);

                uow.TagRepository.Create(entity);
                uow.SaveChanges();

                return new ResponseResult<TagModel>() { Data = model, Message = "Create successed!" };

            }
            catch (Exception)
            {
                return new ResponseResult<TagModel>($"Create failed!");
            }
        }

        public ResponseResult<TagModel> Create(PostModel model)
        {
            throw new NotImplementedException();
        }

        public ResponseResult<TagModel> Delete(Guid tagId)
        {
            try
            {
                if (tagId == Guid.Empty)
                {
                    return new ResponseResult<TagModel>($"Delete failed!");
                }

                var result = uow.TagRepository.Find(tagId);
                if (result == null)
                {
                    return new ResponseResult<TagModel>($"Can't find the category that has id = {tagId}");
                }

                uow.TagRepository.Delete(tagId);
                uow.SaveChanges();

                return new ResponseResult<TagModel>() { Message = "Delete successed!" };

            }
            catch (Exception)
            {
                return new ResponseResult<TagModel>($"Delete failed!");
            }
        }

        public ResponseResult<TagModel> Edit(TagModel model)
        {
            throw new NotImplementedException();
        }

        public ResponseResult<TagModel> Edit(PostModel model)
        {
            throw new NotImplementedException();
        }

        public ResponseResult<TagModel> Find(Guid tagId)
        {
            try
            {
                if (tagId == Guid.Empty)
                {
                    return new ResponseResult<TagModel>($"Invalid tagId");
                }

                var result = uow.TagRepository.Find(tagId);
                if (result == null)
                {
                    return new ResponseResult<TagModel>($"Can't find the category that has id = {tagId}");
                }

                var model = mapper.Map<TagModel>(result);
                return new ResponseResult<TagModel> { Data = model, Message = "Find Successed!" };
            }
            catch (Exception)
            {
                return new ResponseResult<TagModel>($"Find failed!");
            }
        }

        public ResponseResult<TagModel> GetAll()
        {
            ResponseResult<TagModel> response = new ResponseResult<TagModel>();

            try
            {
                var posts = uow.TagRepository.GetAll();
                if (posts == null || posts.Count() == 0)
                {
                    return new ResponseResult<TagModel>() { Message = "No data", StatusCode = 404 };
                }
                var TagModels = mapper.Map<List<TagModel>>(posts);
                return new ResponseResult<TagModel>() { DataList = TagModels, Message = "Success" };
            }
            catch (Exception ex)
            {
                response.Message = "Loi 500 Server";
            }

            return response;
        }
    }
}

using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.ViewModel.Comments;
using FA.JustBlog.ViewModel.Responses;

namespace FA.JustBlog.Service.comment
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public CommentService(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public ResponseResult<CommentModel> Create(CommentModel model)
        {
            try
            {
                if (model == null)
                {
                    return new ResponseResult<CommentModel>($"Create failed!");
                }
                if (string.IsNullOrWhiteSpace(model.Name))
                {
                    return new ResponseResult<CommentModel>($"Create failed!");
                }
                if (model.Name.Length <= 5)
                {
                    return new ResponseResult<CommentModel>($"Create failed!");
                }
                if (model.Email.Length <= 5)
                {
                    return new ResponseResult<CommentModel>($"Create failed!");
                }
                if (model.CommentText.Length <= 5)
                {
                    return new ResponseResult<CommentModel>($"Create failed!");
                }

                if (model.CommentHeader.Length <= 5)
                {
                    return new ResponseResult<CommentModel>($"Create failed!");
                }

                var result = uow.CommentRepository.Find(model.Id);
                if (result == null)
                {
                    return new ResponseResult<CommentModel>($"Can't find the category that has id = {model.Id}");
                }

                model.CommentText = model.CommentText.Replace("<p>", "").Replace("</p>", "");
                model.Email = model.Email.Replace("<p>", "").Replace("</p>", "");
                model.CommentHeader = model.CommentHeader.Replace("<p>", "").Replace("</p>", "");
                var entity = mapper.Map<Comment>(model);

                uow.CommentRepository.Create(entity);
                uow.SaveChanges();

                return new ResponseResult<CommentModel>() { Data = model, Message = "Create successed!" };

            }
            catch (Exception)
            {
                return new ResponseResult<CommentModel>($"Create failed!");
            }
        }

        public ResponseResult<CommentModel> Delete(Guid commentId)
        {
            try
            {
                if (commentId == Guid.Empty)
                {
                    return new ResponseResult<CommentModel>($"Delete failed!");
                }

                var result = uow.CommentRepository.Find(commentId);
                if (result == null)
                {
                    return new ResponseResult<CommentModel>($"Can't find the category that has id = {commentId}");
                }

                uow.CommentRepository.Delete(commentId);
                uow.SaveChanges();

                return new ResponseResult<CommentModel>() { Message = "Delete successed!" };

            }
            catch (Exception)
            {
                return new ResponseResult<CommentModel>($"Delete failed!");
            }
        }

        public ResponseResult<CommentModel> Edit(CommentModel model)
        {
            throw new NotImplementedException();
        }

        public ResponseResult<CommentModel> Find(Guid commentId)
        {
            try
            {
                if (commentId == Guid.Empty)
                {
                    return new ResponseResult<CommentModel>($"Invalid CommentId");
                }

                var result = uow.CommentRepository.Find(commentId);
                if (result == null)
                {
                    return new ResponseResult<CommentModel>($"Can't find the category that has id = {commentId}");
                }

                var model = mapper.Map<CommentModel>(result);
                return new ResponseResult<CommentModel> { Data = model, Message = "Find Successed!" };
            }
            catch (Exception)
            {
                return new ResponseResult<CommentModel>($"Find failed!");
            }
        }

        public ResponseResult<CommentModel> GetAll()
        {
            var result = uow.CommentRepository.GetAll().ToList();
            if (result.Count() > 0)
            {
                var models = mapper.Map<IEnumerable<CommentModel>>(result).ToList();

                return new ResponseResult<CommentModel>() { DataList = models, Message = "Get all succssed!" };
            }

            return new ResponseResult<CommentModel>($"No have any data!");
        }
    }
}

using FA.JustBlog.ViewModel.Comments;
using FA.JustBlog.ViewModel.Responses;

namespace FA.JustBlog.Service.comment
{
    public interface ICommentService
    {
        ResponseResult<CommentModel> GetAll();

        ResponseResult<CommentModel> Find(Guid commentId);

        ResponseResult<CommentModel> Create(CommentModel model);

        ResponseResult<CommentModel> Edit(CommentModel model);

        ResponseResult<CommentModel> Delete(Guid categoryId);
    }
}

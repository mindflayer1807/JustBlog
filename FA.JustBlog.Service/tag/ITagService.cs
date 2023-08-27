using FA.JustBlog.ViewModel.Posts;
using FA.JustBlog.ViewModel.Responses;
using FA.JustBlog.ViewModel.Tags;

namespace FA.JustBlog.Service.tag
{
    public interface ITagService
    {
        ResponseResult<TagModel> GetAll();

        ResponseResult<TagModel> Find(Guid tagId);

        ResponseResult<TagModel> Create(PostModel model);

        ResponseResult<TagModel> Edit(PostModel model);

        ResponseResult<TagModel> Delete(Guid tagId);
    }
}

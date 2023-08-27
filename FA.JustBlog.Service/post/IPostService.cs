using FA.JustBlog.ViewModel.Posts;
using FA.JustBlog.ViewModel.Responses;

namespace FA.JustBlog.Service.post
{
    public interface IPostService
    {
        /// <summary>
        /// Retrieves all posts.
        /// </summary>
        /// <returns>A response containing a result of type PostModel.</returns>
        ResponseResult<PostModel> GetAll();

        /// <summary>
        /// Finds a post by its unique identifier.
        /// </summary>
        /// <param name="postId">The unique identifier of the post.</param>
        /// <returns>A response containing a result of type PostModel.</returns>
        ResponseResult<PostModel> Find(Guid postId);

        /// <summary>
        /// Creates a new post.
        /// </summary>
        /// <param name="model">The PostModel object representing the post to create.</param>
        /// <returns>A response containing a result of type PostModel.</returns>
        ResponseResult<PostModel> Create(PostModel model);

        /// <summary>
        /// Edits an existing post.
        /// </summary>
        /// <param name="model">The PostModel object representing the post to edit.</param>
        /// <returns>A response containing a result of type PostModel.</returns>
        ResponseResult<PostModel> Edit(PostModel model);

        /// <summary>
        /// Deletes a post by its unique identifier.
        /// </summary>
        /// <param name="postId">The unique identifier of the post to delete.</param>
        /// <returns>A response containing a result of type PostModel.</returns>
        ResponseResult<PostModel> Delete(Guid postId);
    }
}

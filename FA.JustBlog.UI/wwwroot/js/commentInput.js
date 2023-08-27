$("#submit-comment").click(function () {
    let postId = $("#post-id").val();
    let name = $('#name').val().trim();
    let commentTime = $('#commentTime').val().trim();
    let email = $('#email').val().trim();
    let commentHeader = $('#commentHeader').val().trim();
    let commentText = $('#commentText').val().trim();


    if (name.length == 0 ||
        email.length == 0 ||
        commentHeader.length == 0) {
        alert("Please input all fills.");
        return;
    }
    $.ajax({
        url: '/comment/add',
        type: 'get',
        data: {
            postId: postId,
            name: name,
            email: email,
            commentTime: commentTime,
            commentHeader: commentHeader,
            commentText: commentText
        },
        success: data => {

            let commentCount = parseInt($("#count-comment").text()) + 1;
            if (commentCount <= 1) {
                $("#count-comment").text(commentCount + " Comment");
            } else {
                $("#count-comment").text(commentCount + " Comments");
            }

            $(".comment-list").prepend(`
                        <div class="commented-section mt-2">
                            <div class="d-flex flex-row align-items-center commented-user">
                                <h5 class="mr-2" > ${name} </h5>
                                 <span class="dot mb-1" style="margin: 0 10px;"></span>
                                 <span class="mb-1 ml-2">${"Just now"}</span>
                             </div>
                            <div class="comment-text-sm" > <span>${commentHeader} </span></div >
                            <div class="comment-text-sm" > <span>${commentText} </span></div >
                            <div class="reply-section">
                                <div class="d-flex flex-row align-items-center voting-icons">
                                    <h6 class="ml-2 mt-1">Like</h6>
                                    <h6 class="ml-2 mt-1" style="margin-left: 10px;">Reply</h6>
                                </div>
                            </div>
                        </div>
                        <!-- Divider-->
                        <hr class="my-4" />                           
            `);
        }
    });
});
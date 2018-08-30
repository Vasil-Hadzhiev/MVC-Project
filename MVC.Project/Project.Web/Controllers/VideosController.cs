namespace Project.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Project.Services.Interfaces;
    using X.PagedList;

    [Authorize]
    public class VideosController : Controller
    {
        private readonly IVideoService videos;

        public VideosController(IVideoService videos)
        {
            this.videos = videos;
        }

        public IActionResult All(int? page)
        {
            //var pageNumber = page ?? 1;

            var videos = this.videos
                .GetVideos();

            //var pagedVideos = videos.ToPagedList(pageNumber, 2);

            return this.View(videos);
        }
    }
}
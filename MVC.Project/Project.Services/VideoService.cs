namespace Project.Services
{
    using Project.Data;
    using Project.Models.ViewModels;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Project.Models.BindingModels;
    using Project.Models.EntityModels;

    public class VideoService : Service, IVideoService
    {
        public VideoService(SportsSystemContext context) 
            : base(context)
        {
        }

        public List<VideosViewModel> GetVideos()
        {
            var videos = this.Context
                .Videos
                .Select(v => new VideosViewModel
                {
                    Title = v.Title,
                    VideoUrl = v.VideoUrl
                })
                .ToList();

            return videos;
        }

        public void Create(CreateVideoBindingModel model)
        {
            var videoUrl = this.GetYouTubeIdFromLink(model.VideoUrl);

            var video = new Video
            {
                Title = model.Title,
                VideoUrl = videoUrl
            };

            this.Context.Videos.Add(video);
            this.Context.SaveChanges();
        }

        private string GetYouTubeIdFromLink(string youTubeLink)
        {
            string youTubeId = null;
            if (youTubeLink.Contains("youtube.com"))
            {
                youTubeId = youTubeLink.Split("?v=")[1];
            }
            else if (youTubeLink.Contains("youtu.be"))
            {
                youTubeId = youTubeLink.Split("/").Last();
            }

            return youTubeId;
        }
    }
}
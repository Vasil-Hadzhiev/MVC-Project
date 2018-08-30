namespace Project.Services.Interfaces
{
    using Project.Models.BindingModels;
    using Project.Models.ViewModels;
    using System.Collections.Generic;

    public interface IVideoService
    {
        List<VideosViewModel> GetVideos();

        void Create(CreateVideoBindingModel model);
    }
}
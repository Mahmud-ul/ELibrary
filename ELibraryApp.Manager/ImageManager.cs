using ELibraryApp.Manager.Base;
using ELibraryApp.Manager.Contract;
using ELibraryApp.Model.Model;
using ELibraryApp.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryApp.Manager
{
    public class ImageManager : BaseManager<Image>, IImageManager
    {
        private readonly IImageRepository _iImageRepository;

        public ImageManager(IImageRepository iImageRepository):base(iImageRepository)
        {
            _iImageRepository = iImageRepository;
        }
    }
}

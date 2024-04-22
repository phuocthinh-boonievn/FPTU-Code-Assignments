using Equipments_Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Equipments_Repository.Repository;

namespace Equipments_NPPThinh.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        public IndexModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Equipment> Equipments { get; set; }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);

        public string Sort { get; set; }


        public IActionResult OnGet(int? pageIndex)
        {
            var user = HttpContext.Session.GetString("CurrentUser");

            if (string.IsNullOrEmpty(user))
            {
                return RedirectToPage("/Login");
            }

            PageIndex = pageIndex ?? 1; 
            PageSize = 5; 


            if (Sort == "ascending")
            {
                var equipmentQuery = _unitOfWork.EquipmentRepository.Get(
                orderBy: q => q.OrderBy(e => e.Quantity),
                //includeProperties: "Rooms",
                pageIndex: PageIndex,
                pageSize: PageSize
                );

                TotalItems = _unitOfWork.EquipmentRepository.Count();

                Equipments = equipmentQuery.ToList();
            }
            else if (Sort == "descending")
            {
                var eyeglassesQuery = _unitOfWork.EquipmentRepository.Get(
                orderBy: q => q.OrderByDescending(e => e.Quantity),
                //includeProperties: "Rooms",
                pageIndex: PageIndex,
                pageSize: PageSize
                );

                TotalItems = _unitOfWork.EquipmentRepository.Count();

                Equipments = eyeglassesQuery.ToList();
            }
            else
            {
                var eyeglassesQuery = _unitOfWork.EquipmentRepository.Get(
                orderBy: q => q.OrderByDescending(e => e.CreatedAt).ThenBy(e => e.EqId),
                //includeProperties: "Rooms",
                pageIndex: PageIndex,
                pageSize: PageSize
                );

                TotalItems = _unitOfWork.EquipmentRepository.Count();

                Equipments = eyeglassesQuery.ToList();
            }

            return Page();
        }

        public IActionResult OnPost(int? pageIndex, int? pageSize)
        {
            var user = HttpContext.Session.GetString("CurrentUser");

            if (string.IsNullOrEmpty(user))
            {
                return RedirectToPage("/Login");
            }

            PageIndex = pageIndex ?? 1; // Sử dụng giá trị trang mặc định là 1 nếu không có giá trị được truyền vào
            PageSize = pageSize ?? 5; // Sử dụng giá trị kích thước trang mặc định là 10 nếu không có giá trị được truyền vào

            Sort = Request.Form["sortOrder"];



            if (Sort == "ascending")
            {
                var eyeglassesQuery = _unitOfWork.EquipmentRepository.Get(
                orderBy: q => q.OrderBy(e => e.Quantity),
                //includeProperties: "RoomId",
                pageIndex: PageIndex,
                pageSize: PageSize
                );

                TotalItems = _unitOfWork.EquipmentRepository.Count();

                Equipments = eyeglassesQuery.ToList();

            }
            else if (Sort == "descending")
            {
                var eyeglassesQuery = _unitOfWork.EquipmentRepository.Get(
                orderBy: q => q.OrderByDescending(e => e.Quantity),
                //includeProperties: "Rooms",
                pageIndex: PageIndex,
                pageSize: PageSize
                );

                TotalItems = _unitOfWork.EquipmentRepository.Count();

                Equipments = eyeglassesQuery.ToList();
            }
            else
            {
                var eyeglassesQuery = _unitOfWork.EquipmentRepository.Get(
                orderBy: q => q.OrderByDescending(e => e.CreatedAt).ThenBy(e => e.EqId),
                //includeProperties: "Rooms",
                pageIndex: PageIndex,
                pageSize: PageSize
                );

                TotalItems = _unitOfWork.EquipmentRepository.Count();

                Equipments = eyeglassesQuery.ToList();
            }



            return Page();
        }
    }
}
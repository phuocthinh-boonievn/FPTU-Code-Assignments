using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Equipments_Repository.Models;
using Equipments_Repository.Repository;

namespace Equipments_NPPThinh.Pages
{
    public class EquipmentListModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        public EquipmentListModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Equipment> Equipments { get; set; }

        [BindProperty(SupportsGet = true)] //  cho phép thuộc tính SearchString được gắn kết với dữ liệu được truyền vào từ yêu cầu HTTP theo phương thức GET
        public string SearchString { get; set; }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);

        public void OnGet(int? pageIndex, string searchString)
        {
            PageIndex = pageIndex ?? 1; // Sử dụng giá trị trang mặc định là 1 nếu không có giá trị được truyền vào
            PageSize = 5; // Sử dụng giá trị kích thước trang mặc định là 10 nếu không có giá trị được truyền vào
            SearchString = searchString;

            var eqquimentsQuery = _unitOfWork.EquipmentRepository.Get(
                    filter: p => p.Quantity.ToString().Contains(SearchString) || p.EqName.Contains(SearchString),
                    orderBy: q => q.OrderByDescending(e => e.Quantity).ThenBy(e => e.EqId),
                    //includeProperties: "RoomID",
                    pageIndex: PageIndex,
                    pageSize: PageSize
                    );

            TotalItems = _unitOfWork.EquipmentRepository.Count(filter: p => p.Quantity.ToString().Contains(SearchString) || p.EqName.Contains(SearchString));

            Equipments = eqquimentsQuery.ToList();
        }
    }
    
}

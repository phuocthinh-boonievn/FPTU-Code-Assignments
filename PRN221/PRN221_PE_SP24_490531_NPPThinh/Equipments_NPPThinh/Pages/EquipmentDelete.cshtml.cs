using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Equipments_Repository.Repository;

namespace Equipments_NPPThinh.Pages
{
    public class EquipmentDeleteModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        public EquipmentDeleteModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet(int equipmentId)
        {
            var equipment = _unitOfWork.EquipmentRepository.GetByID(equipmentId);

            _unitOfWork.EquipmentRepository.Delete(equipment);
            _unitOfWork.SaveChange();

            return RedirectToPage("/Index");
        }
    }
}

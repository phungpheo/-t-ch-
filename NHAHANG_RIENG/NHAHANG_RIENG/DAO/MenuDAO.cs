using NHAHANG_RIENG.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NHAHANG_RIENG.DAO
{
    public class MenuDAO
    {
       private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get {
                if (instance == null) instance = new MenuDAO();
                return MenuDAO.instance;
            }
           private set => instance = value;
        }
        
        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> listMenu = new List<Menu>();

            string query = "select Food.NAME as N'Tên', BiIfo.COUNT as N'Số lượng', Food.GIA as N'Giá', Food.GIA*BiIfo.COUNT as N'Thành tiền' from dbo.BILLINFO as BiIfo, dbo.BILL as Bill, dbo.FOOD as Food where BiIfo.IDBILL = Bill.ID and BiIfo.IDFOOD = Food.ID and Bill.status =0 and IDTABLE= " + id;
            DataTable data;
            data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}

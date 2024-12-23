using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQuanLySinhVien.common
{
    class ExportExcel
    {
        public static void XuatExcel(string path, List<string> list, string header, string footer, params string[] titles)
        {
            //Thực hiện nối chuối header vào trong chuỗi result và cho xuống 2 dòng
            string result = string.Format("{0}\n\r", header);
            //Tieu de
            //So sánh mảng titles nếu không có giá trị thì không thực hiện nối chuỗi title.
            if (titles != null)
            {
                //Thực hiện lặp trên mảng titles để lấy từng giá trị trong mảng nối vào chuỗi result.
                foreach (var item in titles)
                {
                    result += string.Format("{0}\t", item, UnicodeEncoding.UTF8);
                }
            }
            //Sau khi nối các giá trị của title ta tiến hành cho xuống dòng
            result += "\n";
            //Thực hiện lặp để lấy nội dung. Khi này nội dung của ta lưu trên nhiều dòng và mỗi dòng có nhiều giá trị. Giống như duyệt một mảng 2 chiều để lấy được giá trị
            foreach (string item in list)
            {
                string[] vs = item.Split(',');
                foreach (var subitem in vs)
                {
                    result += string.Format("{0}\t", subitem, UnicodeEncoding.UTF8);
                }
                result += "\n";
            }
            //Sau khi ghi hết giá trị trong list<string>) tiến hành xuống dòng và nối footer vào trong kết quả
            result += "\n" + footer;
            //Thực hiện gọi hàm ghi file với nội dung là chuỗi result nhận được sau quá trình nối chuỗi
            GhiFile(path, result);
        }
        private static void GhiFile(string path, string contents)
        {
            //Kiểm tra file theo đường dẫn có tồn tại. nếu có rồi sẽ xóa file cũ đi,
            if (File.Exists(path))
            {
                File.Delete(path);//Xoa file neu ton tai
            }
            //Sử dụng lớp FileStream
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                //Ghi file theo chuẩn Unicode.
                //Để ghi file có font unicode vào file Excel ta thêm một thuộc tính trong hàm tạo của lớp StreamWriter là UTF8Encoding.Unicode.
                using (StreamWriter sw = new StreamWriter(fs, UTF8Encoding.Unicode))
                {
                    //Phương thức WriteLine dùng để ghi một đoạn string lên file text. sau đó xuống dòng
                    sw.WriteLine(contents);
                }
            }

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_tl
{
    public class SinhVien
    {
     
        private string _hoTen;
        private double _diemTB;
        public string MaSV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string HoTen
        {
            get { return _hoTen; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Họ tên không được rỗng.");
                _hoTen = value.Trim();
            }
        }
        public double DiemTB
        {
            get { return _diemTB; }
            set
            {
                if (value < 0 || value > 10)
                    throw new ArgumentOutOfRangeException("DiemTB", "Điểm phải từ 0 đến 10.");
                _diemTB = value;
            }
        }
        public SinhVien()
        {
            MaSV = "Chưa có";
            HoTen = "Chưa có";
            NgaySinh = DateTime.Today;
            DiemTB = 0;
        }
        public SinhVien(string maSV, string hoTen, DateTime ngaySinh, double diemTB)
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiemTB = diemTB;
        }
        public int TinhTuoi()
        {
            int tuoi = DateTime.Today.Year - NgaySinh.Year;
            if (NgaySinh.Date > DateTime.Today.AddYears(-tuoi)) tuoi--;
            return tuoi;
        }
        public string XepLoai()
        {
            if (DiemTB >= 9) return "Xuất sắc";
            if (DiemTB >= 8) return "Giỏi";
            if (DiemTB >= 6.5) return "Khá";
            if (DiemTB >= 5) return "Trung bình";
            return "Yếu";
        }
        public void HienThi()
        {
            Console.WriteLine("{0} - {1} - {2:dd/MM/yyyy} ({3} tuổi) - Điểm: {4:N2} - Xếp loại: {5}",
                MaSV, HoTen, NgaySinh, TinhTuoi(), DiemTB, XepLoai());
        }
        static void main(string[] args)
        {
            SinhVien sv1 = new SinhVien("SV001", "Nguyen Van A", new DateTime(2000, 5, 15), 8.5);
            sv1.HienThi();
            SinhVien sv2 = new SinhVien();
            sv2.HienThi();
        }

    }
}
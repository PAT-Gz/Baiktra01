
using System;

using System.Collections.Generic;

using System.Linq;


namespace baitap02_10

{

    // =========================================================

    // A. ABSTRACT CLASS PHUONG TIEN

    // =========================================================

    public abstract class PhuongTien

    {

        // Private Fields

        private string _maPT;

        private string _tenHang;

        private int _namSanXuat;

        private decimal _giaGoc;

        // -----------------------------------------------------

        // Property MaPT

        // -----------------------------------------------------

        public string MaPT

        {

            get

            {

                return _maPT;

            }

            set

            {

                if (string.IsNullOrWhiteSpace(value))

                {

                    _maPT = "PT000";

                }

                else

                {

                    _maPT = value;

                }

            }

        }

        // -----------------------------------------------------

        // Property TenHang

        // -----------------------------------------------------

        public string TenHang

        {

            get

            {

                return _tenHang;

            }

            set

            {

                if (string.IsNullOrWhiteSpace(value))

                {

                    throw new ArgumentException(

                        "Tên hãng không được để trống!");

                }

                _tenHang = value;

            }

        }

        // -----------------------------------------------------

        // Property NamSanXuat

        // -----------------------------------------------------

        public int NamSanXuat

        {

            get

            {

                return _namSanXuat;

            }

            set

            {

                int namHienTai = DateTime.Now.Year;

                if (value < 1900 || value > namHienTai)

                {

                    throw new ArgumentException(

                        "Năm sản xuất phải từ 1900 đến "

                        + namHienTai + "!");

                }

                _namSanXuat = value;

            }

        }

        // -----------------------------------------------------

        // Property GiaGoc

        // -----------------------------------------------------

        public decimal GiaGoc

        {

            get

            {

                return _giaGoc;

            }

            set

            {

                if (value <= 0)

                {

                    throw new ArgumentException(

                        "Giá gốc phải lớn hơn 0!");

                }

                _giaGoc = value;

            }

        }

        // -----------------------------------------------------

        // Constructor
        // -----------------------------------------------------

        public PhuongTien(

            string maPT,

            string tenHang,

            int namSanXuat,

            decimal giaGoc)

        {

            MaPT = maPT;

            TenHang = tenHang;

            NamSanXuat = namSanXuat;

            GiaGoc = giaGoc;

        }

        // -----------------------------------------------------

        // Abstract Method

        // -----------------------------------------------------

        public abstract decimal TinhGiaLanBanh();

        // -----------------------------------------------------

        // Virtual Method

        // -----------------------------------------------------

        public virtual string GetInfo()

        {

            return "Mã PT: " + MaPT

                + " | Hãng: " + TenHang

                + " | Năm SX: " + NamSanXuat

                + " | Giá gốc: "

                + GiaGoc.ToString("N0")

                + " VNĐ";

        }

    }

    // ====================
    public class OTo : PhuongTien

    {

        // Private Fields

        private int _soChoNgoi;

        private double _dungTichDongCo;

        // -----------------------------------------------------

        // Property SoChoNgoi

        // -----------------------------------------------------

        public int SoChoNgoi

        {

            get

            {

                return _soChoNgoi;

            }

            set

            {

                if (value <= 0)

                {

                    throw new ArgumentException(

                        "Số chỗ ngồi phải lớn hơn 0!");

                }

                _soChoNgoi = value;

            }

        }

        // -----------------------------------------------------

        // Property DungTichDongCo

        // -----------------------------------------------------

        public double DungTichDongCo

        {

            get

            {

                return _dungTichDongCo;

            }

            set

            {

                if (value <= 0)

                {

                    throw new ArgumentException(

                        "Dung tích động cơ phải lớn hơn 0!");

                }

                _dungTichDongCo = value;

            }

        }

        // -----------------------------------------------------

        // Constructor

        // -----------------------------------------------------

        public OTo(

            string maPT,

            string tenHang,

            int namSanXuat,

            decimal giaGoc,

            int soChoNgoi,

            double dungTichDongCo)

            : base(

                maPT,

                tenHang,

                namSanXuat,

                giaGoc)

        {

            SoChoNgoi = soChoNgoi;

            DungTichDongCo = dungTichDongCo;

        }

        // -----------------------------------------------------

        // Override TinhGiaLanBanh

        // -----------------------------------------------------

        public override decimal TinhGiaLanBanh()

        {

            if (SoChoNgoi <= 9)

            {

                // Giá gốc

                // + 12% lệ phí trước bạ

                // + 30% thuế tiêu thụ đặc biệt

                return GiaGoc

                    + GiaGoc * 0.12m

                    + GiaGoc * 0.30m;

            }

            else

            {

                // Giá gốc + 10% lệ phí trước bạ

                return GiaGoc

                    + GiaGoc * 0.10m;

            }

        }

        // -----------------------------------------------------

        // Override GetInfo

        // -----------------------------------------------------

        public override string GetInfo()

        {

            return base.GetInfo()

                + " | Số chỗ: " + SoChoNgoi

                + " | Động cơ: "

                + DungTichDongCo + " L";
        }

        public class XeMay : PhuongTien

        {

            // Private Field

            private int _dungTichXylanh;

            // -----------------------------------------------------

            // Property DungTichXylanh

            // -----------------------------------------------------

            public int DungTichXylanh

            {

                get

                {

                    return _dungTichXylanh;

                }

                set

                {

                    if (value <= 0)

                    {

                        throw new ArgumentException(

                            "Dung tích xilanh phải lớn hơn 0!");

                    }

                    _dungTichXylanh = value;

                }

            }

            // -----------------------------------------------------

            // Constructor

            // -----------------------------------------------------

            public XeMay(

                string maPT,

                string tenHang,

                int namSanXuat,

                decimal giaGoc,

                int dungTichXylanh)

                : base(

                    maPT,

                    tenHang,

                    namSanXuat,

                    giaGoc)

            {

                DungTichXylanh = dungTichXylanh;

            }

            // -----------------------------------------------------

            // Override TinhGiaLanBanh

            // -----------------------------------------------------

            public override decimal TinhGiaLanBanh()

            {

                if (DungTichXylanh < 175)

                {

                    // Giá gốc + 2% trước bạ

                    return GiaGoc

                        + GiaGoc * 0.02m;

                }

                else

                {

                    // Giá gốc + 5% trước bạ

                    return GiaGoc

                        + GiaGoc * 0.05m;

                }

            }

            // -----------------------------------------------------

            // Override GetInfo

            // -----------------------------------------------------

            public override string GetInfo()

            {

                return base.GetInfo()

                    + " | Xilanh: "

                    + DungTichXylanh

                    + " cc";

            }

        }

        // =========================================================

        // D. CLASS QUAN LY PHUONG TIEN

        // =========================================================

        public class QuanLyPhuongTien

        {

            // Danh sách phương tiện

            private List<PhuongTien> danhSach;

            // -----------------------------------------------------

            // Constructor

            // -----------------------------------------------------

            public QuanLyPhuongTien()

            {

                danhSach =

                    new List<PhuongTien>();

            }

            // -----------------------------------------------------

            // 1. AddPhuongTien

            // -----------------------------------------------------

            public void AddPhuongTien(

                PhuongTien pt)

            {

                if (pt == null)

                {

                    throw new ArgumentNullException(

                        "pt",

                        "Phương tiện không được null!");

                }

                danhSach.Add(pt);

            }

            // -----------------------------------------------------

            // 2. DisplayAll

            // -----------------------------------------------------

            public void DisplayAll()

            {

                Console.WriteLine();

                Console.WriteLine(

                    "========== DANH SACH PHUONG TIEN ==========");

                if (danhSach.Count == 0)

                {

                    Console.WriteLine(

                        "Danh sach dang rong!");

                    return;

                }

                foreach (PhuongTien pt in danhSach)

                {

                    Console.WriteLine(

                        pt.GetInfo());

                    Console.WriteLine(

                        "Gia lan banh: "

                        + pt.TinhGiaLanBanh()

                            .ToString("N0")

                        + " VNĐ");

                    Console.WriteLine(

                        "--------------------------------------------");

                }

            }

            // -----------------------------------------------------

            // 3. FindMaxGiaLanBanh

            // -----------------------------------------------------

            public PhuongTien FindMaxGiaLanBanh()

            {

                if (danhSach.Count == 0)

                {

                    return null;

                }

                return danhSach

                    .OrderByDescending(

                        pt => pt.TinhGiaLanBanh())

                    .First();

            }

            // -----------------------------------------------------

            // 4. SearchByName

            // -----------------------------------------------------

            public List<PhuongTien> SearchByName(

                string keyword)

            {

                if (string.IsNullOrWhiteSpace(keyword))

                {

                    return new List<PhuongTien>();

                }

                return danhSach

                    .Where(

                        pt => pt.TenHang

                            .IndexOf(

                                keyword,

                                StringComparison

                                    .OrdinalIgnoreCase) >= 0)

                    .ToList();

            }

        }

        // ==========
        class Program

        {

            static void Main(string[] args)

            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.InputEncoding = System.Text.Encoding.UTF8;

                try

                {

                    // =================================================

                    // TẠO ĐỐI TƯỢNG QUẢN LÝ

                    // =================================================

                    QuanLyPhuongTien ql =

                        new QuanLyPhuongTien();

                    // =================================================

                    // TẠO Ô TÔ

                    // =================================================

                    OTo oto1 =

                        new OTo(

                            "OT001",

                            "Toyota",

                            2023,

                            800000000m,

                            7,

                            2.0);

                    OTo oto2 =

                        new OTo(

                            "OT002",

                            "Hyundai",

                            2022,

                            600000000m,

                            16,

                            2.5);

                    // =================================================

                    // TẠO XE MÁY

                    // =================================================

                    XeMay xeMay1 =

                        new XeMay(

                            "XM001",

                            "Honda",

                            2024,

                            50000000m,

                            125);

                    XeMay xeMay2 =

                        new XeMay(

                            "XM002",

                            "Yamaha",

                            2023,

                            70000000m,

                            200);

                    // =================================================

                    // THÊM VÀO DANH SÁCH

                    // =================================================

                    ql.AddPhuongTien(oto1);

                    ql.AddPhuongTien(oto2);

                    ql.AddPhuongTien(xeMay1);

                    ql.AddPhuongTien(xeMay2);

                    // =================================================

                    // HIỂN THỊ TOÀN BỘ

                    // =================================================

                    ql.DisplayAll();

                    // =================================================

                    // TÌM GIÁ LĂN BÁNH CAO NHẤT

                    // =================================================

                    PhuongTien max =

                        ql.FindMaxGiaLanBanh();

                    Console.WriteLine();

                    Console.WriteLine(

                        "===== PHUONG TIEN GIA LAN BANH CAO NHAT =====");

                    if (max != null)

                    {

                        Console.WriteLine(

                            max.GetInfo());

                        Console.WriteLine(

                            "Gia lan banh: "

                            + max.TinhGiaLanBanh()

                                .ToString("N0")
                                + " VNĐ");

                    }

                    // =================================================

                    // TÌM KIẾM THEO TÊN HÃNG

                    // =================================================

                    Console.WriteLine();

                    Console.Write(

                        "Nhap ten hang can tim: ");

                    string keyword =

                        Console.ReadLine();

                    List<PhuongTien> ketQua =

                        ql.SearchByName(keyword);

                    Console.WriteLine();

                    Console.WriteLine(

                        "========== KET QUA TIM KIEM ==========");

                    if (ketQua.Count == 0)

                    {

                        Console.WriteLine(

                            "Khong tim thay phuong tien!");

                    }

                    else

                    {

                        foreach (

                            PhuongTien pt

                            in ketQua)

                        {

                            Console.WriteLine(

                                pt.GetInfo());

                            Console.WriteLine(

                                "Gia lan banh: "

                                + pt.TinhGiaLanBanh()

                                    .ToString("N0")

                                + " VNĐ");

                            Console.WriteLine(

                                "--------------------------------------------");

                        }

                    }

                }

                catch (ArgumentException ex)

                {

                    Console.WriteLine();

                    Console.WriteLine(

                        "LOI DU LIEU: "

                        + ex.Message);

                }

                catch (Exception ex)

                {

                    Console.WriteLine();

                    Console.WriteLine(

                        "LOI: "

                        + ex.Message);

                }

                Console.WriteLine();

                Console.WriteLine(

                    "Nhan phim bat ky de thoat...");

                Console.ReadKey();

            }

        }

    }
}
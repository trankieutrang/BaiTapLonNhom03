using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using btlquanlycuahanginternet.Class;

namespace btlquanlycuahanginternet
{
    public partial class frmMayTinh : Form
    {
        DataTable tblMT;
        public frmMayTinh()
        {
            InitializeComponent();
        }

        private void frmMayTinh_Load(object sender, EventArgs e)
        {
            Class.functions.Connect();
            txtmamay.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            loadDataToGridView();
        }
        private void loadDataToGridView()
        {
            string sql = "select * from MayTinh";
            DataTable tblMT = Class.functions.GetDataToTable(sql);
            dataGridView_maytinh.DataSource = tblMT;
        }

        private void dataGridView_maytinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmamay.Focus();
                return;
            }
            txtmamay.Text = dataGridView_maytinh.CurrentRow.Cells["MaMay"].Value.ToString();
            txttenmt.Text = dataGridView_maytinh.CurrentRow.Cells["TenMay"].Value.ToString();
            txtmaphong.Text = dataGridView_maytinh.CurrentRow.Cells["MaPhong"].Value.ToString();
            functions.FillCombo("SELECT MaOCung, TenOCung FROM O_Cung", cboOCung, "MaOCung", "TenOCung");
            cboOCung.SelectedIndex = -1;
            functions.FillCombo("SELECT MaDLuong, TenDLuong FROM Dung_Luong", cboDLuong, "MaDLuong", "TenDLuong");
            cboOCung.SelectedIndex = -1;
            functions.FillCombo("SELECT MaChip, TenChip FROM Chip", cboChip, "MaChip", "TenChip");
            cboOCung.SelectedIndex = -1;
            functions.FillCombo("SELECT MaRam, TenRam FROM Ram", cboRam, "MaRam", "TenRam");
            cboOCung.SelectedIndex = -1;
            functions.FillCombo("SELECT MaTocDo, TenTocDo FROM Toc_Do", cboTocDo, "MaTocDo", "TenTocDo");
            cboOCung.SelectedIndex = -1;
            functions.FillCombo("SELECT MaManHinh, TenManHinh FROM Man_Hinh", cboMH, "MaManHinh", "TenManHinh");
            cboOCung.SelectedIndex = -1;
            functions.FillCombo("SELECT MaSizeMH, TenSizeMH FROM SizeMH", cboSizeMH, "MaSizeMH", "TenSizeMH");
            cboOCung.SelectedIndex = -1;
            functions.FillCombo("SELECT MaChuot, TenChuot FROM Chuot", cboChuot, "MaChuot", "TenChuot");
            cboOCung.SelectedIndex = -1;
            functions.FillCombo("SELECT MaBanPhim, TenBanPhim FROM BanPhim", cboBPhim, "MaBanPhim", "TenBanPhim");
            cboOCung.SelectedIndex = -1;
            functions.FillCombo("SELECT MaODia, TenODia FROM O_Dia", cboODia, "MaODia", "TenODia");
            cboOCung.SelectedIndex = -1;
            functions.FillCombo("SELECT MaLoa, TenLoa FROM Loa", cboLoa, "MaLoa", "TenLoa");
            cboOCung.SelectedIndex = -1;
            txttinhtrang.Text = dataGridView_maytinh.CurrentRow.Cells["TinhTrang"].Value.ToString();
            txtghichu.Text = dataGridView_maytinh.CurrentRow.Cells["GhiChu"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtmamay.Enabled = true;
            txtmamay.Focus();
            ResetValues();
            loadDataToGridView();
        }
        private void ResetValues()
        {
            txtmamay.Text = "";
            txttenmt.Text = "";
            txtmaphong.Text = "";
            txttinhtrang.Text = "";
            cboOCung.Text = "";
            cboDLuong.Text = "";
            cboChip.Text = "";
            cboRam.Text = "";
            cboTocDo.Text = "";
            cboMH.Text = "";
            cboSizeMH.Text = "";
            cboChuot.Text = "";
            cboBPhim.Text = "";
            cboODia.Text = "";
            cboLoa.Text = "";
            txtghichu.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmamay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã máy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmamay.Focus();
                return;
            }
            if (txttenmt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên máy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenmt.Focus();
                return;
            }
            if (txtmaphong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaphong.Focus();
                return;
            }
            if (txttinhtrang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tình trạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttinhtrang.Focus();
                return;
            }
            if (cboOCung.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã ổ cứng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboOCung.Focus();
                return;
            }
            if (cboDLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã dung lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDLuong.Focus();
                return;
            }
            if (cboChip.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã chip", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboChip.Focus();
                return;
            }
            if (cboRam.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã ram", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttinhtrang.Focus();
                return;
            }
            if (cboTocDo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã tốc độ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTocDo.Focus();
                return;
            }
            if (cboMH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã màn hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMH.Focus();
                return;
            }
            if (cboSizeMH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã size màn hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboSizeMH.Focus();
                return;
            }
            if (cboBPhim.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã bàn phím", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboBPhim.Focus();
                return;
            }
            if (cboODia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã ổ đĩa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboODia.Focus();
                return;
            }
            if (cboChuot.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã chuột", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDLuong.Focus();
                return;
            }
            if (cboLoa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã loa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboLoa.Focus();
                return;
            }
            sql = "SELECT MaMay FROM MayTinh WHERE MaMay=N'" + txtmamay.Text.Trim() + "'";
            if (functions.CheckKey(sql))
            {
                MessageBox.Show("Mã máy này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmamay.Focus();
                return;
            }
            sql = "INSERT INTO MayTinh(MaMay,TenMay,MaPhong,MaOCung,MaDLuong,MaChip,MaRam,MaTocDo,MaManHinh,MaSizeMH,MaChuot,MaBanPhim," +
                "MaODia,MaLoa,TinhTrang,Ghichu) VALUES('"
                + txtmamay.Text.Trim() + "','" + txttenmt.Text.Trim() +"','" + txtmaphong.Text.ToString() +"'," +
                "'" + cboOCung.SelectedValue.ToString() + ",'" + cboDLuong.SelectedValue.ToString() +"','" + cboChip.SelectedValue.ToString() + "'," +
                "'" + cboRam.SelectedValue.ToString() + "','" + cboTocDo.SelectedValue.ToString() + "','" + cboMH.SelectedValue.ToString()+"'," +
                "'" + cboSizeMH.SelectedValue.ToString()+ "','" + cboChuot.SelectedValue.ToString() + "','" + cboBPhim.SelectedValue.ToString() + "'," +
                "'" + cboODia.SelectedValue.ToString() + "','" + cboLoa.SelectedValue.ToString() + "','" + txttinhtrang.Text.ToString() + "'," +
                "'" + txtghichu.Text.ToString() + "')";

            functions.RunSQL(sql);
            loadDataToGridView();
            //ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtmamay.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmamay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã máy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmamay.Focus();
                return;
            }
            if (txttenmt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên máy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenmt.Focus();
                return;
            }
            if (txtmaphong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaphong.Focus();
                return;
            }
            if (txttinhtrang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tình trạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttinhtrang.Focus();
                return;
            }
            if (cboOCung.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã ổ cứng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboOCung.Focus();
                return;
            }
            if (cboDLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã dung lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDLuong.Focus();
                return;
            }
            if (cboChip.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã chip", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboChip.Focus();
                return;
            }
            if (cboRam.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã ram", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttinhtrang.Focus();
                return;
            }
            if (cboTocDo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã tốc độ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTocDo.Focus();
                return;
            }
            if (cboMH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã màn hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMH.Focus();
                return;
            }
            if (cboSizeMH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã size màn hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboSizeMH.Focus();
                return;
            }
            if (cboBPhim.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã bàn phím", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboBPhim.Focus();
                return;
            }
            if (cboODia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã ổ đĩa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboODia.Focus();
                return;
            }
            if (cboChuot.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã chuột", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDLuong.Focus();
                return;
            }
            if (cboLoa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã loa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboLoa.Focus();
                return;
            }
            sql = "UPDATE MayTinh SET TenMay='" + txttenmt.Text.Trim() + "',MaPhong='" + txtmaphong.Text.ToString() + "',MaOCung='" +
                "MaRam='" + cboOCung.SelectedValue.ToString() + ",MaDLuong='" + cboDLuong.SelectedValue.ToString() + "',MaChip='" + cboChip.SelectedValue.ToString() + "'," +
                "'" + cboRam.SelectedValue.ToString() + "',MaTocDo='" + cboTocDo.SelectedValue.ToString() + "',MaManHinh='" + cboMH.SelectedValue.ToString() + "'," +
                "MaSizeMH='" + cboSizeMH.SelectedValue.ToString() + "',MaChuot='" + cboChuot.SelectedValue.ToString() + "',MaBanPhim='" + cboBPhim.SelectedValue.ToString() + "'," +
                "MaODia='" + cboODia.SelectedValue.ToString() + "',MaLoa='" + cboLoa.SelectedValue.ToString() + "',TinhTrang='" + txttinhtrang.Text.ToString() + "'," +
                "GhiChu='" + txtghichu.Text.ToString() + "')";
            functions.RunSQL(sql);
            loadDataToGridView();
            ResetValues();
            btnHuy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblMT.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmamay.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblHang WHERE MaHang=N'" + txtmamay.Text + "'";
                functions.RunSqlDel(sql);
                loadDataToGridView();
                ResetValues();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtmamay.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

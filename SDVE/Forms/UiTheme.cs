using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SDVE.Forms
{
    /// <summary>
    /// Shared presentation-only styling for the application's existing forms.
    /// </summary>
    internal static class UiTheme
    {
        private static readonly Color Navy = Color.FromArgb(13, 49, 111);
        private static readonly Color Blue = Color.FromArgb(35, 78, 145);
        private static readonly Color LightBlue = Color.FromArgb(128, 170, 219);
        private static readonly Color Lavender = Color.FromArgb(157, 164, 204);
        private static readonly Color Canvas = Color.FromArgb(249, 248, 252);
        private static readonly Color Text = Color.FromArgb(38, 48, 66);
        private static readonly Color Border = Color.FromArgb(221, 222, 235);

        internal static void Apply(Form form)
        {
            form.BackColor = Canvas;
            form.ForeColor = Text;
            if (form.Name == "FrmLogin")
            {
                string logoPath = Path.Combine(AppContext.BaseDirectory, "Resources", "login-logo-watermark.png");
                if (File.Exists(logoPath))
                {
                    form.BackgroundImage = Image.FromFile(logoPath);
                    form.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
            StyleControls(form.Controls, form.Name);
            if (form.Name == "FrmPrincipalAdmin")
                StyleAdminButtons(form);
        }

        internal static void StyleAdminButtons(Form form)
        {
            StyleButton(form, "btnConvocatorias", Blue, Color.White, Color.FromArgb(52, 104, 176));
            StyleButton(form, "btnCandidatos", Color.FromArgb(42, 91, 157), Color.White, Color.FromArgb(52, 104, 176));
            StyleButton(form, "btnResultados", Navy, Color.White, Blue);
            StyleButton(form, "btnExportacion", LightBlue, Navy, Color.FromArgb(160, 193, 230));
        }

        private static void StyleButton(Form form, string name, Color backColor, Color foreColor, Color hoverColor)
        {
            Control[] matches = form.Controls.Find(name, true);
            if (matches.Length == 0 || matches[0] is not Button button)
                return;

            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = hoverColor;
            button.FlatAppearance.MouseDownBackColor = Navy;
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;
        }

        private static void StyleControls(Control.ControlCollection controls, string formName)
        {
            Color headerColor = HeaderColor(formName);
            bool lightHeader = formName is "FrmAgregarCandidatto" or "FrmEditarCandidato1" or "FrmConvocatorias" or "FrmInicio" or "FrmExportacion";

            foreach (Control control in controls)
            {
                if (control is Button button)
                {
                    bool inMenu = button.Parent?.Name == "pnlMenu";
                    bool contentAction = button.Parent?.Name == "pnlContenido";
                    bool loginButton = formName == "FrmLogin";
                    bool logoutButton = button.Text.Contains("cerrar sesi", System.StringComparison.OrdinalIgnoreCase);
                    bool secondary = button.Text.Contains("regresar", System.StringComparison.OrdinalIgnoreCase)
                        || button.Text.Contains("cancelar", System.StringComparison.OrdinalIgnoreCase);
                    bool destructive = button.Text.Contains("eliminar", System.StringComparison.OrdinalIgnoreCase);
                    bool orangeAction = button.Text.Contains("continuar", System.StringComparison.OrdinalIgnoreCase)
                        || button.Text.Contains("exportar", System.StringComparison.OrdinalIgnoreCase)
                        || button.Text.Contains("activar", System.StringComparison.OrdinalIgnoreCase);
                    bool confirmAction = button.Text.Contains("confirmar", System.StringComparison.OrdinalIgnoreCase);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = secondary ? 1 : 0;
                    button.FlatAppearance.BorderColor = inMenu ? Lavender : Border;
                    button.BackColor = contentAction ? ContentButtonColor(button.Name)
                        : loginButton ? Navy
                        : inMenu ? (logoutButton ? Color.FromArgb(42, 91, 157) : Blue)
                        : destructive || confirmAction ? Blue
                        : secondary ? Lavender
                        : orangeAction ? LightBlue
                        : Blue;
                    button.ForeColor = contentAction && button.Name == "btnExportacion" || secondary || orangeAction ? Navy : Color.White;
                    button.FlatAppearance.MouseOverBackColor = contentAction ? ContentButtonHoverColor(button.Name)
                        : loginButton ? Blue
                        : inMenu ? Color.FromArgb(55, 110, 176)
                        : destructive || confirmAction ? Color.FromArgb(52, 104, 176)
                        : secondary ? Color.FromArgb(182, 187, 218)
                        : orangeAction ? Color.FromArgb(160, 193, 230)
                        : Navy;
                    button.FlatAppearance.MouseDownBackColor = Navy;
                    button.Cursor = Cursors.Hand;
                    button.UseVisualStyleBackColor = false;
                }
                else if (control is DataGridView grid)
                {
                    grid.BackgroundColor = Color.White;
                    grid.BorderStyle = BorderStyle.None;
                    grid.EnableHeadersVisualStyles = false;
                    grid.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
                    grid.ColumnHeadersDefaultCellStyle.ForeColor = lightHeader ? Navy : Color.White;
                    grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = headerColor;
                    grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = lightHeader ? Navy : Color.White;
                    grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
                    grid.DefaultCellStyle.BackColor = Color.White;
                    grid.DefaultCellStyle.ForeColor = Text;
                    grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 230, 246);
                    grid.DefaultCellStyle.SelectionForeColor = Text;
                    grid.GridColor = Border;
                    grid.RowHeadersVisible = false;
                    grid.RowTemplate.Height = 34;
                }
                else if (control is TextBox || control is ComboBox)
                {
                    control.BackColor = Color.White;
                    control.ForeColor = Text;
                    if (formName == "FrmLogin" && control is TextBox textBox)
                        textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (control is Label label && label.BackColor != Color.FromArgb(51, 55, 113))
                {
                    if (label.Name == "lblAdmin")
                    {
                        label.ForeColor = Color.White;
                    }
                    else if (label.Name == "lblTitulo")
                    {
                        label.ForeColor = Navy;
                    }
                    else if (label.Name == "lblSubtitulo")
                    {
                        label.ForeColor = Blue;
                    }
                    else
                    {
                        label.ForeColor = Text;
                    }
                }
                else if (control is Label header && header.BackColor == Color.FromArgb(51, 55, 113))
                {
                    header.BackColor = headerColor;
                    header.ForeColor = lightHeader ? Navy : Color.White;
                    bool adminSideDecoration = formName == "FrmPrincipalAdmin" && header.Name != "label1";
                    if (header.Name != "lblLogo" && !adminSideDecoration)
                    {
                        header.BackgroundImage = CreateHeaderBackground(header, headerColor, lightHeader);
                        header.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (adminSideDecoration)
                    {
                        header.BackgroundImage = null;
                    }
                }
                else if (control is Panel panel)
                {
                    panel.BackColor = panel.Name == "pnlMenu" ? Navy
                        : panel.Name == "pnlContenido" ? Canvas
                        : Color.White;
                }

                if (control.HasChildren)
                    StyleControls(control.Controls, formName);
            }
        }

        private static Color HeaderColor(string formName) => formName switch
        {
            "FrmAgregarCandidatto" or "FrmEditarCandidato1" or "FrmConvocatorias" or "FrmInicio" => Lavender,
            "FrmConfirmacion" or "FrmVotacion" => Blue,
            "FrmExportacion" => LightBlue,
            "FrmPrincipalAdmin" => Blue,
            _ => Navy
        };

        private static Color ContentButtonColor(string buttonName) => buttonName switch
        {
            "btnConvocatorias" => Color.FromArgb(35, 78, 145),
            "btnCandidatos" => Color.FromArgb(48, 94, 158),
            "btnResultados" => Color.FromArgb(23, 59, 118),
            "btnExportacion" => Color.FromArgb(102, 151, 207),
            _ => Blue
        };

        private static Color ContentButtonHoverColor(string buttonName) => buttonName switch
        {
            "btnExportacion" => Color.FromArgb(160, 193, 230),
            "btnResultados" => Color.FromArgb(35, 78, 145),
            _ => Color.FromArgb(52, 104, 176)
        };

        private static Bitmap CreateHeaderBackground(Label header, Color backgroundColor, bool lightHeader)
        {
            var background = new Bitmap(Math.Max(1, header.Width), Math.Max(1, header.Height));
            using (var graphics = Graphics.FromImage(background))
            {
                graphics.Clear(backgroundColor);
                string markPath = Path.Combine(AppContext.BaseDirectory, "Resources", "eagle-mark.png");
                if (File.Exists(markPath))
                {
                    using var mark = Image.FromFile(markPath);
                    using var attributes = new System.Drawing.Imaging.ImageAttributes();
                    var tint = new System.Drawing.Imaging.ColorMatrix
                    {
                        Matrix00 = 0,
                        Matrix11 = 0,
                        Matrix22 = 0,
                        Matrix33 = 0.68F,
                        Matrix40 = lightHeader ? Navy.R / 255F : 1F,
                        Matrix41 = lightHeader ? Navy.G / 255F : 1F,
                        Matrix42 = lightHeader ? Navy.B / 255F : 1F
                    };
                    attributes.SetColorMatrix(tint);

                    int markHeight = Math.Min(42, Math.Max(1, header.Height - 8));
                    int markWidth = Math.Max(1, markHeight * mark.Width / mark.Height);
                    var destination = new Rectangle(header.Width - markWidth - 12, (header.Height - markHeight) / 2, markWidth, markHeight);
                    graphics.DrawImage(mark, destination, 0, 0, mark.Width, mark.Height, GraphicsUnit.Pixel, attributes);
                }

            }

            return background;
        }
    }
}

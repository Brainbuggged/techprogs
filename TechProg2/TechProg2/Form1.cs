using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPLab2;


namespace TechProg2
{
    public partial class Form1 : Form, IOleClientSite, IOleInPlaceSite
    {


        readonly tagRECT myRect = new tagRECT(0, 0, 500, 400);
        public Form1()
        {
            OLE.CoInitializeEx(IntPtr.Zero, 2);
            InitializeComponent();
            axShockwaveFlash1.Movie = Application.StartupPath + @"\tuma.swf";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            object browser = OLE.CoCreateInstance(OLE.CLASS_WEBBROWSER, null,
                  OLE.CLSCTX.CLSCTX_INPROC_SERVER,
                  OLE.IID_IWebBrowser2);
            IOleObject obj = browser as IOleObject;
            tagRECT rect = new tagRECT();
            obj.SetClientSite(this);
            obj.DoVerb((int)OLEDOVERB.OLEIVERB_INPLACEACTIVATE,
                IntPtr.Zero, this, 0, Handle, ref rect
                );
            IWebBrowser2 brow = browser as IWebBrowser2;
            (brow as IWebBrowser2).Navigate("http://ya.ru", null, null, null, null);
        }

        [return: MarshalAs(UnmanagedType.I4)]
        public int SaveObject()
        {
            return HRESULT.S_OK;
        }

        [return: MarshalAs(UnmanagedType.I4)]
        public int GetMoniker([In, MarshalAs(UnmanagedType.U4)] uint dwAssign, [In, MarshalAs(UnmanagedType.U4)] uint dwWhichMoniker, [MarshalAs(UnmanagedType.Interface), Out] out IMoniker ppmk)
        {
            ppmk = null;
            return HRESULT.E_FAIL;
        }

        [return: MarshalAs(UnmanagedType.I4)]
        public int GetContainer([MarshalAs(UnmanagedType.Interface), Out] out IOleContainer ppContainer)
        {
            ppContainer = null;
            return HRESULT.E_NOINTERFACE;
        }

        [return: MarshalAs(UnmanagedType.I4)]
        public int ShowObject()
        {
            return HRESULT.S_OK;
        }

        [return: MarshalAs(UnmanagedType.I4)]
        public int OnShowWindow([In, MarshalAs(UnmanagedType.Bool)] bool fShow)
        {
            return HRESULT.S_OK;
        }

        [return: MarshalAs(UnmanagedType.I4)]
        public int RequestNewObjectLayout()
        {
            return HRESULT.S_OK;
        }

        [return: MarshalAs(UnmanagedType.I4)]
        public int GetWindow([In, Out] ref IntPtr phwnd)
        {
            phwnd = groupBox1.Handle;
            return HRESULT.S_OK;
        }

        [return: MarshalAs(UnmanagedType.I4)]
        public int ContextSensitiveHelp([In, MarshalAs(UnmanagedType.Bool)] bool fEnterMode)
        {
            return HRESULT.S_OK;
        }

        [return: MarshalAs(UnmanagedType.I4)]
        public int CanInPlaceActivate()
        {
            return HRESULT.S_OK;
        }

        [return: MarshalAs(UnmanagedType.I4)]
        public int OnInPlaceActivate()
        {
            return HRESULT.S_OK;
        }

        [return: MarshalAs(UnmanagedType.I4)]
        public int OnUIActivate()
        {
            return HRESULT.S_OK;
        }

        [return: MarshalAs(UnmanagedType.I4)]
        public int GetWindowContext([MarshalAs(UnmanagedType.Interface), Out] out IOleInPlaceFrame ppFrame, [MarshalAs(UnmanagedType.Interface), Out] out IOleInPlaceUIWindow ppDoc, [In, MarshalAs(UnmanagedType.Struct), Out] ref tagRECT lprcPosRect, [In, MarshalAs(UnmanagedType.Struct), Out] ref tagRECT lprcClipRect, [In, MarshalAs(UnmanagedType.Struct), Out] ref tagOIFI lpFrameInfo)
        {
            ppFrame = null;
            ppDoc = null;
            lprcPosRect = myRect;
            lprcClipRect = myRect;
            return HRESULT.S_OK;
        }

        int IOleInPlaceSite.Scroll(ref tagSIZE scrollExtent)
        {
            return HRESULT.S_OK;
        }

        [return: MarshalAs(UnmanagedType.I4)]
        public int OnUIDeactivate([In, MarshalAs(UnmanagedType.Bool)] bool fUndoable)
        {
            return HRESULT.S_OK;
        }

        [return: MarshalAs(UnmanagedType.I4)]
        public int OnInPlaceDeactivate()
        {
            return HRESULT.S_OK;
        }

        [return: MarshalAs(UnmanagedType.I4)]
        public int DiscardUndoState()
        {
            return HRESULT.S_OK;
        }

        [return: MarshalAs(UnmanagedType.I4)]
        public int DeactivateAndUndo()
        {
            return HRESULT.S_OK;
        }

        [return: MarshalAs(UnmanagedType.I4)]
        public int OnPosRectChange([In, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcPosRect)
        {
            lprcPosRect = myRect;
            return HRESULT.S_OK;
        }
    }
}

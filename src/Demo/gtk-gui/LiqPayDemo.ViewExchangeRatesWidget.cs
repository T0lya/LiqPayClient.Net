
// This file has been generated by the GUI designer. Do not modify.
namespace LiqPayDemo
{
	public partial class ViewExchangeRatesWidget
	{
		private global::Gtk.VBox contentVBox;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.TextView exchangeRatesTextView;

		private global::Gtk.HButtonBox buttonBox;

		private global::Gtk.Button refreshButton;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget LiqPayDemo.ViewExchangeRatesWidget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "LiqPayDemo.ViewExchangeRatesWidget";
			// Container child LiqPayDemo.ViewExchangeRatesWidget.Gtk.Container+ContainerChild
			this.contentVBox = new global::Gtk.VBox ();
			this.contentVBox.Name = "contentVBox";
			this.contentVBox.Spacing = 6;
			// Container child contentVBox.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.exchangeRatesTextView = new global::Gtk.TextView ();
			this.exchangeRatesTextView.CanFocus = true;
			this.exchangeRatesTextView.Name = "exchangeRatesTextView";
			this.exchangeRatesTextView.Editable = false;
			this.GtkScrolledWindow.Add (this.exchangeRatesTextView);
			this.contentVBox.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.contentVBox[this.GtkScrolledWindow]));
			w2.Position = 0;
			// Container child contentVBox.Gtk.Box+BoxChild
			this.buttonBox = new global::Gtk.HButtonBox ();
			this.buttonBox.Name = "buttonBox";
			this.buttonBox.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(3));
			// Container child buttonBox.Gtk.ButtonBox+ButtonBoxChild
			this.refreshButton = new global::Gtk.Button ();
			this.refreshButton.CanFocus = true;
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.UseUnderline = true;
			this.refreshButton.Label = global::Mono.Unix.Catalog.GetString ("Refresh");
			this.buttonBox.Add (this.refreshButton);
			global::Gtk.ButtonBox.ButtonBoxChild w3 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.buttonBox[this.refreshButton]));
			w3.Expand = false;
			w3.Fill = false;
			this.contentVBox.Add (this.buttonBox);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.contentVBox[this.buttonBox]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.Add (this.contentVBox);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.refreshButton.Clicked += new global::System.EventHandler (this.OnRefreshExchangeRatesClicked);
		}
	}
}
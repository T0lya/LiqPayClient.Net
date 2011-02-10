
// This file has been generated by the GUI designer. Do not modify.
namespace LiqPayDemo
{
	public partial class ViewTransactionWidget
	{
		private global::Gtk.Table contentTable;

		private global::Gtk.Entry amountEntry;

		private global::Gtk.Label amountLabel;

		private global::Gtk.Entry currencyEntry;

		private global::Gtk.Label currencyLabel;

		private global::Gtk.Entry descriptionEntry;

		private global::Gtk.Label descriptionLabel;

		private global::Gtk.Entry fromEntry;

		private global::Gtk.Label fromLabel;

		private global::Gtk.HSeparator hseparator3;

		private global::Gtk.HSeparator hseparator4;

		private global::Gtk.Entry merchantIdEntry;

		private global::Gtk.Label merchantIdLabel;

		private global::Gtk.Entry orderIdEntry;

		private global::Gtk.Label orderIdLabel;

		private global::Gtk.Entry pwdEntry;

		private global::Gtk.Label pwdLabel;

		private global::Gtk.Entry refererEntry;

		private global::Gtk.Label refererLabel;

		private global::Gtk.Entry searchOrderIdEntry;

		private global::Gtk.Label searchOrderIdLabel;

		private global::Gtk.Entry searchTransactionIdEntry;

		private global::Gtk.Label searchTransactionIdLabel;

		private global::Gtk.Entry toEntry;

		private global::Gtk.Label toLabel;

		private global::Gtk.Entry transactionIDEntry;

		private global::Gtk.Label transactionIdLabel;

		private global::Gtk.Button viewTransactionButton;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget LiqPayDemo.ViewTransactionWidget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "LiqPayDemo.ViewTransactionWidget";
			// Container child LiqPayDemo.ViewTransactionWidget.Gtk.Container+ContainerChild
			this.contentTable = new global::Gtk.Table (((uint)(14)), ((uint)(2)), false);
			this.contentTable.Name = "contentTable";
			this.contentTable.RowSpacing = ((uint)(6));
			this.contentTable.ColumnSpacing = ((uint)(6));
			// Container child contentTable.Gtk.Table+TableChild
			this.amountEntry = new global::Gtk.Entry ();
			this.amountEntry.CanFocus = true;
			this.amountEntry.Name = "amountEntry";
			this.amountEntry.IsEditable = false;
			this.amountEntry.InvisibleChar = '●';
			this.contentTable.Add (this.amountEntry);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.contentTable[this.amountEntry]));
			w1.TopAttach = ((uint)(9));
			w1.BottomAttach = ((uint)(10));
			w1.LeftAttach = ((uint)(1));
			w1.RightAttach = ((uint)(2));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.amountLabel = new global::Gtk.Label ();
			this.amountLabel.Name = "amountLabel";
			this.amountLabel.Xalign = 1f;
			this.amountLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Amount:");
			this.contentTable.Add (this.amountLabel);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.contentTable[this.amountLabel]));
			w2.TopAttach = ((uint)(9));
			w2.BottomAttach = ((uint)(10));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.currencyEntry = new global::Gtk.Entry ();
			this.currencyEntry.CanFocus = true;
			this.currencyEntry.Name = "currencyEntry";
			this.currencyEntry.IsEditable = false;
			this.currencyEntry.InvisibleChar = '●';
			this.contentTable.Add (this.currencyEntry);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.contentTable[this.currencyEntry]));
			w3.TopAttach = ((uint)(10));
			w3.BottomAttach = ((uint)(11));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.currencyLabel = new global::Gtk.Label ();
			this.currencyLabel.Name = "currencyLabel";
			this.currencyLabel.Xalign = 1f;
			this.currencyLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Currency:");
			this.contentTable.Add (this.currencyLabel);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.contentTable[this.currencyLabel]));
			w4.TopAttach = ((uint)(10));
			w4.BottomAttach = ((uint)(11));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.descriptionEntry = new global::Gtk.Entry ();
			this.descriptionEntry.CanFocus = true;
			this.descriptionEntry.Name = "descriptionEntry";
			this.descriptionEntry.IsEditable = false;
			this.descriptionEntry.InvisibleChar = '●';
			this.contentTable.Add (this.descriptionEntry);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.contentTable[this.descriptionEntry]));
			w5.TopAttach = ((uint)(11));
			w5.BottomAttach = ((uint)(12));
			w5.LeftAttach = ((uint)(1));
			w5.RightAttach = ((uint)(2));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.descriptionLabel = new global::Gtk.Label ();
			this.descriptionLabel.Name = "descriptionLabel";
			this.descriptionLabel.Xalign = 1f;
			this.descriptionLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Description:");
			this.contentTable.Add (this.descriptionLabel);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.contentTable[this.descriptionLabel]));
			w6.TopAttach = ((uint)(11));
			w6.BottomAttach = ((uint)(12));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.fromEntry = new global::Gtk.Entry ();
			this.fromEntry.CanFocus = true;
			this.fromEntry.Name = "fromEntry";
			this.fromEntry.IsEditable = false;
			this.fromEntry.InvisibleChar = '●';
			this.contentTable.Add (this.fromEntry);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.contentTable[this.fromEntry]));
			w7.TopAttach = ((uint)(7));
			w7.BottomAttach = ((uint)(8));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(2));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.fromLabel = new global::Gtk.Label ();
			this.fromLabel.Name = "fromLabel";
			this.fromLabel.Xalign = 1f;
			this.fromLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("From:");
			this.contentTable.Add (this.fromLabel);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.contentTable[this.fromLabel]));
			w8.TopAttach = ((uint)(7));
			w8.BottomAttach = ((uint)(8));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.hseparator3 = new global::Gtk.HSeparator ();
			this.hseparator3.Name = "hseparator3";
			this.contentTable.Add (this.hseparator3);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.contentTable[this.hseparator3]));
			w9.TopAttach = ((uint)(4));
			w9.BottomAttach = ((uint)(5));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.hseparator4 = new global::Gtk.HSeparator ();
			this.hseparator4.Name = "hseparator4";
			this.contentTable.Add (this.hseparator4);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.contentTable[this.hseparator4]));
			w10.TopAttach = ((uint)(4));
			w10.BottomAttach = ((uint)(5));
			w10.LeftAttach = ((uint)(1));
			w10.RightAttach = ((uint)(2));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.merchantIdEntry = new global::Gtk.Entry ();
			this.merchantIdEntry.CanFocus = true;
			this.merchantIdEntry.Name = "merchantIdEntry";
			this.merchantIdEntry.IsEditable = true;
			this.merchantIdEntry.InvisibleChar = '●';
			this.contentTable.Add (this.merchantIdEntry);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.contentTable[this.merchantIdEntry]));
			w11.LeftAttach = ((uint)(1));
			w11.RightAttach = ((uint)(2));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.merchantIdLabel = new global::Gtk.Label ();
			this.merchantIdLabel.Name = "merchantIdLabel";
			this.merchantIdLabel.Xalign = 1f;
			this.merchantIdLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Merchant ID:");
			this.contentTable.Add (this.merchantIdLabel);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.contentTable[this.merchantIdLabel]));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.orderIdEntry = new global::Gtk.Entry ();
			this.orderIdEntry.CanFocus = true;
			this.orderIdEntry.Name = "orderIdEntry";
			this.orderIdEntry.IsEditable = false;
			this.orderIdEntry.InvisibleChar = '●';
			this.contentTable.Add (this.orderIdEntry);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.contentTable[this.orderIdEntry]));
			w13.TopAttach = ((uint)(6));
			w13.BottomAttach = ((uint)(7));
			w13.LeftAttach = ((uint)(1));
			w13.RightAttach = ((uint)(2));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.orderIdLabel = new global::Gtk.Label ();
			this.orderIdLabel.Name = "orderIdLabel";
			this.orderIdLabel.Xalign = 1f;
			this.orderIdLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Order ID:");
			this.contentTable.Add (this.orderIdLabel);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.contentTable[this.orderIdLabel]));
			w14.TopAttach = ((uint)(6));
			w14.BottomAttach = ((uint)(7));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.pwdEntry = new global::Gtk.Entry ();
			this.pwdEntry.CanFocus = true;
			this.pwdEntry.Name = "pwdEntry";
			this.pwdEntry.IsEditable = true;
			this.pwdEntry.InvisibleChar = '●';
			this.contentTable.Add (this.pwdEntry);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.contentTable[this.pwdEntry]));
			w15.TopAttach = ((uint)(1));
			w15.BottomAttach = ((uint)(2));
			w15.LeftAttach = ((uint)(1));
			w15.RightAttach = ((uint)(2));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.pwdLabel = new global::Gtk.Label ();
			this.pwdLabel.Name = "pwdLabel";
			this.pwdLabel.Xalign = 1f;
			this.pwdLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Password:");
			this.contentTable.Add (this.pwdLabel);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.contentTable[this.pwdLabel]));
			w16.TopAttach = ((uint)(1));
			w16.BottomAttach = ((uint)(2));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.refererEntry = new global::Gtk.Entry ();
			this.refererEntry.CanFocus = true;
			this.refererEntry.Name = "refererEntry";
			this.refererEntry.IsEditable = false;
			this.refererEntry.InvisibleChar = '●';
			this.contentTable.Add (this.refererEntry);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.contentTable[this.refererEntry]));
			w17.TopAttach = ((uint)(12));
			w17.BottomAttach = ((uint)(13));
			w17.LeftAttach = ((uint)(1));
			w17.RightAttach = ((uint)(2));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.refererLabel = new global::Gtk.Label ();
			this.refererLabel.Name = "refererLabel";
			this.refererLabel.Xalign = 1f;
			this.refererLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Referer URL:");
			this.contentTable.Add (this.refererLabel);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.contentTable[this.refererLabel]));
			w18.TopAttach = ((uint)(12));
			w18.BottomAttach = ((uint)(13));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.searchOrderIdEntry = new global::Gtk.Entry ();
			this.searchOrderIdEntry.CanFocus = true;
			this.searchOrderIdEntry.Name = "searchOrderIdEntry";
			this.searchOrderIdEntry.IsEditable = true;
			this.searchOrderIdEntry.InvisibleChar = '●';
			this.contentTable.Add (this.searchOrderIdEntry);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.contentTable[this.searchOrderIdEntry]));
			w19.TopAttach = ((uint)(3));
			w19.BottomAttach = ((uint)(4));
			w19.LeftAttach = ((uint)(1));
			w19.RightAttach = ((uint)(2));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.searchOrderIdLabel = new global::Gtk.Label ();
			this.searchOrderIdLabel.Name = "searchOrderIdLabel";
			this.searchOrderIdLabel.Xalign = 1f;
			this.searchOrderIdLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Order ID:");
			this.contentTable.Add (this.searchOrderIdLabel);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.contentTable[this.searchOrderIdLabel]));
			w20.TopAttach = ((uint)(3));
			w20.BottomAttach = ((uint)(4));
			w20.XOptions = ((global::Gtk.AttachOptions)(4));
			w20.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.searchTransactionIdEntry = new global::Gtk.Entry ();
			this.searchTransactionIdEntry.CanFocus = true;
			this.searchTransactionIdEntry.Name = "searchTransactionIdEntry";
			this.searchTransactionIdEntry.IsEditable = true;
			this.searchTransactionIdEntry.InvisibleChar = '●';
			this.contentTable.Add (this.searchTransactionIdEntry);
			global::Gtk.Table.TableChild w21 = ((global::Gtk.Table.TableChild)(this.contentTable[this.searchTransactionIdEntry]));
			w21.TopAttach = ((uint)(2));
			w21.BottomAttach = ((uint)(3));
			w21.LeftAttach = ((uint)(1));
			w21.RightAttach = ((uint)(2));
			w21.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.searchTransactionIdLabel = new global::Gtk.Label ();
			this.searchTransactionIdLabel.Name = "searchTransactionIdLabel";
			this.searchTransactionIdLabel.Xalign = 1f;
			this.searchTransactionIdLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Transaction ID:");
			this.contentTable.Add (this.searchTransactionIdLabel);
			global::Gtk.Table.TableChild w22 = ((global::Gtk.Table.TableChild)(this.contentTable[this.searchTransactionIdLabel]));
			w22.TopAttach = ((uint)(2));
			w22.BottomAttach = ((uint)(3));
			w22.XOptions = ((global::Gtk.AttachOptions)(4));
			w22.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.toEntry = new global::Gtk.Entry ();
			this.toEntry.CanFocus = true;
			this.toEntry.Name = "toEntry";
			this.toEntry.IsEditable = false;
			this.toEntry.InvisibleChar = '●';
			this.contentTable.Add (this.toEntry);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.contentTable[this.toEntry]));
			w23.TopAttach = ((uint)(8));
			w23.BottomAttach = ((uint)(9));
			w23.LeftAttach = ((uint)(1));
			w23.RightAttach = ((uint)(2));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.toLabel = new global::Gtk.Label ();
			this.toLabel.Name = "toLabel";
			this.toLabel.Xalign = 1f;
			this.toLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("To:");
			this.contentTable.Add (this.toLabel);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.contentTable[this.toLabel]));
			w24.TopAttach = ((uint)(8));
			w24.BottomAttach = ((uint)(9));
			w24.XOptions = ((global::Gtk.AttachOptions)(4));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.transactionIDEntry = new global::Gtk.Entry ();
			this.transactionIDEntry.CanFocus = true;
			this.transactionIDEntry.Name = "transactionIDEntry";
			this.transactionIDEntry.IsEditable = false;
			this.transactionIDEntry.InvisibleChar = '●';
			this.contentTable.Add (this.transactionIDEntry);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.contentTable[this.transactionIDEntry]));
			w25.TopAttach = ((uint)(5));
			w25.BottomAttach = ((uint)(6));
			w25.LeftAttach = ((uint)(1));
			w25.RightAttach = ((uint)(2));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.transactionIdLabel = new global::Gtk.Label ();
			this.transactionIdLabel.Name = "transactionIdLabel";
			this.transactionIdLabel.Xalign = 1f;
			this.transactionIdLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Transaction ID:");
			this.contentTable.Add (this.transactionIdLabel);
			global::Gtk.Table.TableChild w26 = ((global::Gtk.Table.TableChild)(this.contentTable[this.transactionIdLabel]));
			w26.TopAttach = ((uint)(5));
			w26.BottomAttach = ((uint)(6));
			w26.XOptions = ((global::Gtk.AttachOptions)(4));
			w26.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.viewTransactionButton = new global::Gtk.Button ();
			this.viewTransactionButton.CanFocus = true;
			this.viewTransactionButton.Name = "viewTransactionButton";
			this.viewTransactionButton.UseUnderline = true;
			this.viewTransactionButton.Label = global::Mono.Unix.Catalog.GetString ("View");
			this.contentTable.Add (this.viewTransactionButton);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.contentTable[this.viewTransactionButton]));
			w27.TopAttach = ((uint)(13));
			w27.BottomAttach = ((uint)(14));
			w27.XOptions = ((global::Gtk.AttachOptions)(4));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add (this.contentTable);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.viewTransactionButton.Clicked += new global::System.EventHandler (this.OnViewTransactionClicked);
		}
	}
}

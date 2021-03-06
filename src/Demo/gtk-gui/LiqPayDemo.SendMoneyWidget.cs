
// This file has been generated by the GUI designer. Do not modify.
namespace LiqPayDemo
{
	public partial class SendMoneyWidget
	{
		private global::Gtk.Table contentTable;
		private global::Gtk.Entry amountEntry;
		private global::Gtk.Label amountLabel;
		private global::Gtk.ComboBoxEntry currencyComboBox;
		private global::Gtk.Label currencyLabel;
		private global::Gtk.Entry descriptionEntry;
		private global::Gtk.Label descriptionLabel;
		private global::Gtk.HSeparator hseparator1;
		private global::Gtk.HSeparator hseparator2;
		private global::Gtk.ComboBox kindComboBox;
		private global::Gtk.Label kindLabel;
		private global::Gtk.Entry merchantIdEntry;
		private global::Gtk.Label merchantIdLabel;
		private global::Gtk.Entry orderIdEntry;
		private global::Gtk.Label orderIdLabel;
		private global::Gtk.Entry pwdEntry;
		private global::Gtk.Label pwdLabel;
		private global::Gtk.Button sendMoneyButton;
		private global::Gtk.Entry toEntry;
		private global::Gtk.Label toLabel;
		private global::Gtk.Label transactionIdFieldLabel;
		private global::Gtk.Label transactionIdLabel;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget LiqPayDemo.SendMoneyWidget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "LiqPayDemo.SendMoneyWidget";
			// Container child LiqPayDemo.SendMoneyWidget.Gtk.Container+ContainerChild
			this.contentTable = new global::Gtk.Table (((uint)(11)), ((uint)(2)), false);
			this.contentTable.Name = "contentTable";
			this.contentTable.RowSpacing = ((uint)(6));
			this.contentTable.ColumnSpacing = ((uint)(6));
			// Container child contentTable.Gtk.Table+TableChild
			this.amountEntry = new global::Gtk.Entry ();
			this.amountEntry.CanFocus = true;
			this.amountEntry.Name = "amountEntry";
			this.amountEntry.IsEditable = true;
			this.amountEntry.InvisibleChar = '●';
			this.contentTable.Add (this.amountEntry);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.contentTable [this.amountEntry]));
			w1.TopAttach = ((uint)(4));
			w1.BottomAttach = ((uint)(5));
			w1.LeftAttach = ((uint)(1));
			w1.RightAttach = ((uint)(2));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.amountLabel = new global::Gtk.Label ();
			this.amountLabel.Name = "amountLabel";
			this.amountLabel.Xalign = 1F;
			this.amountLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Amount:");
			this.contentTable.Add (this.amountLabel);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.contentTable [this.amountLabel]));
			w2.TopAttach = ((uint)(4));
			w2.BottomAttach = ((uint)(5));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.currencyComboBox = global::Gtk.ComboBoxEntry.NewText ();
			this.currencyComboBox.Name = "currencyComboBox";
			this.contentTable.Add (this.currencyComboBox);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.contentTable [this.currencyComboBox]));
			w3.TopAttach = ((uint)(5));
			w3.BottomAttach = ((uint)(6));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.currencyLabel = new global::Gtk.Label ();
			this.currencyLabel.Name = "currencyLabel";
			this.currencyLabel.Xalign = 1F;
			this.currencyLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Currency:");
			this.contentTable.Add (this.currencyLabel);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.contentTable [this.currencyLabel]));
			w4.TopAttach = ((uint)(5));
			w4.BottomAttach = ((uint)(6));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.descriptionEntry = new global::Gtk.Entry ();
			this.descriptionEntry.CanFocus = true;
			this.descriptionEntry.Name = "descriptionEntry";
			this.descriptionEntry.IsEditable = true;
			this.descriptionEntry.InvisibleChar = '●';
			this.contentTable.Add (this.descriptionEntry);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.contentTable [this.descriptionEntry]));
			w5.TopAttach = ((uint)(7));
			w5.BottomAttach = ((uint)(8));
			w5.LeftAttach = ((uint)(1));
			w5.RightAttach = ((uint)(2));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.descriptionLabel = new global::Gtk.Label ();
			this.descriptionLabel.Name = "descriptionLabel";
			this.descriptionLabel.Xalign = 1F;
			this.descriptionLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Description:");
			this.contentTable.Add (this.descriptionLabel);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.contentTable [this.descriptionLabel]));
			w6.TopAttach = ((uint)(7));
			w6.BottomAttach = ((uint)(8));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.hseparator1 = new global::Gtk.HSeparator ();
			this.hseparator1.Name = "hseparator1";
			this.contentTable.Add (this.hseparator1);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.contentTable [this.hseparator1]));
			w7.TopAttach = ((uint)(8));
			w7.BottomAttach = ((uint)(9));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(2));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.hseparator2 = new global::Gtk.HSeparator ();
			this.hseparator2.Name = "hseparator2";
			this.contentTable.Add (this.hseparator2);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.contentTable [this.hseparator2]));
			w8.TopAttach = ((uint)(8));
			w8.BottomAttach = ((uint)(9));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.kindComboBox = global::Gtk.ComboBox.NewText ();
			this.kindComboBox.AppendText (global::Mono.Unix.Catalog.GetString ("Phone"));
			this.kindComboBox.AppendText (global::Mono.Unix.Catalog.GetString ("Card"));
			this.kindComboBox.Name = "kindComboBox";
			this.kindComboBox.Active = 0;
			this.contentTable.Add (this.kindComboBox);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.contentTable [this.kindComboBox]));
			w9.TopAttach = ((uint)(2));
			w9.BottomAttach = ((uint)(3));
			w9.LeftAttach = ((uint)(1));
			w9.RightAttach = ((uint)(2));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.kindLabel = new global::Gtk.Label ();
			this.kindLabel.Name = "kindLabel";
			this.kindLabel.Xalign = 1F;
			this.kindLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Kind:");
			this.contentTable.Add (this.kindLabel);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.contentTable [this.kindLabel]));
			w10.TopAttach = ((uint)(2));
			w10.BottomAttach = ((uint)(3));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.merchantIdEntry = new global::Gtk.Entry ();
			this.merchantIdEntry.CanFocus = true;
			this.merchantIdEntry.Name = "merchantIdEntry";
			this.merchantIdEntry.IsEditable = true;
			this.merchantIdEntry.InvisibleChar = '●';
			this.contentTable.Add (this.merchantIdEntry);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.contentTable [this.merchantIdEntry]));
			w11.LeftAttach = ((uint)(1));
			w11.RightAttach = ((uint)(2));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.merchantIdLabel = new global::Gtk.Label ();
			this.merchantIdLabel.Name = "merchantIdLabel";
			this.merchantIdLabel.Xalign = 1F;
			this.merchantIdLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Merchant ID:");
			this.contentTable.Add (this.merchantIdLabel);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.contentTable [this.merchantIdLabel]));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.orderIdEntry = new global::Gtk.Entry ();
			this.orderIdEntry.CanFocus = true;
			this.orderIdEntry.Name = "orderIdEntry";
			this.orderIdEntry.IsEditable = true;
			this.orderIdEntry.InvisibleChar = '●';
			this.contentTable.Add (this.orderIdEntry);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.contentTable [this.orderIdEntry]));
			w13.TopAttach = ((uint)(6));
			w13.BottomAttach = ((uint)(7));
			w13.LeftAttach = ((uint)(1));
			w13.RightAttach = ((uint)(2));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.orderIdLabel = new global::Gtk.Label ();
			this.orderIdLabel.Name = "orderIdLabel";
			this.orderIdLabel.Xalign = 1F;
			this.orderIdLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Order ID:");
			this.contentTable.Add (this.orderIdLabel);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.contentTable [this.orderIdLabel]));
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
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.contentTable [this.pwdEntry]));
			w15.TopAttach = ((uint)(1));
			w15.BottomAttach = ((uint)(2));
			w15.LeftAttach = ((uint)(1));
			w15.RightAttach = ((uint)(2));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.pwdLabel = new global::Gtk.Label ();
			this.pwdLabel.Name = "pwdLabel";
			this.pwdLabel.Xalign = 1F;
			this.pwdLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Password:");
			this.contentTable.Add (this.pwdLabel);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.contentTable [this.pwdLabel]));
			w16.TopAttach = ((uint)(1));
			w16.BottomAttach = ((uint)(2));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.sendMoneyButton = new global::Gtk.Button ();
			this.sendMoneyButton.CanFocus = true;
			this.sendMoneyButton.Name = "sendMoneyButton";
			this.sendMoneyButton.UseUnderline = true;
			this.sendMoneyButton.Label = global::Mono.Unix.Catalog.GetString ("Send");
			this.contentTable.Add (this.sendMoneyButton);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.contentTable [this.sendMoneyButton]));
			w17.TopAttach = ((uint)(10));
			w17.BottomAttach = ((uint)(11));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.toEntry = new global::Gtk.Entry ();
			this.toEntry.CanFocus = true;
			this.toEntry.Name = "toEntry";
			this.toEntry.IsEditable = true;
			this.toEntry.InvisibleChar = '●';
			this.contentTable.Add (this.toEntry);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.contentTable [this.toEntry]));
			w18.TopAttach = ((uint)(3));
			w18.BottomAttach = ((uint)(4));
			w18.LeftAttach = ((uint)(1));
			w18.RightAttach = ((uint)(2));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.toLabel = new global::Gtk.Label ();
			this.toLabel.Name = "toLabel";
			this.toLabel.Xalign = 1F;
			this.toLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("To:");
			this.contentTable.Add (this.toLabel);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.contentTable [this.toLabel]));
			w19.TopAttach = ((uint)(3));
			w19.BottomAttach = ((uint)(4));
			w19.XOptions = ((global::Gtk.AttachOptions)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.transactionIdFieldLabel = new global::Gtk.Label ();
			this.transactionIdFieldLabel.Name = "transactionIdFieldLabel";
			this.transactionIdFieldLabel.Xalign = 1F;
			this.transactionIdFieldLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Transaction ID:");
			this.contentTable.Add (this.transactionIdFieldLabel);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.contentTable [this.transactionIdFieldLabel]));
			w20.TopAttach = ((uint)(9));
			w20.BottomAttach = ((uint)(10));
			w20.XOptions = ((global::Gtk.AttachOptions)(4));
			w20.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child contentTable.Gtk.Table+TableChild
			this.transactionIdLabel = new global::Gtk.Label ();
			this.transactionIdLabel.Name = "transactionIdLabel";
			this.transactionIdLabel.Xalign = 0F;
			this.contentTable.Add (this.transactionIdLabel);
			global::Gtk.Table.TableChild w21 = ((global::Gtk.Table.TableChild)(this.contentTable [this.transactionIdLabel]));
			w21.TopAttach = ((uint)(9));
			w21.BottomAttach = ((uint)(10));
			w21.LeftAttach = ((uint)(1));
			w21.RightAttach = ((uint)(2));
			w21.XOptions = ((global::Gtk.AttachOptions)(4));
			w21.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add (this.contentTable);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.sendMoneyButton.Clicked += new global::System.EventHandler (this.OnSendMoneyClicked);
		}
	}
}

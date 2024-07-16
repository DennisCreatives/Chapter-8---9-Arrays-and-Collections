Public Class Form1

    'Public structure to define Product data type
    Structure Product
        Dim ProductIDString As String
        Dim DescriptionString As String
        Dim QuantityInteger As Integer
        Dim PriceDecimal As Decimal
    End Structure

    Structure Sale
        Dim SaleIDString As String
        Dim SaleDate As Date
        Dim SaleDecimal As Decimal
    End Structure

    'Module-level variables/constants/arrays
    Private NumberProductInteger As Integer = 7
    Private InventoryProduct(NumberProductInteger) As Product
    Private TotalDueDecimal As Decimal

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InventoryProduct(0).ProductIDString = "A402"
        InventoryProduct(0).DescriptionString = "History of America 
Textbook"
        InventoryProduct(0).QuantityInteger = 10
        InventoryProduct(0).PriceDecimal = 65.55D
        InventoryProduct(1).ProductIDString = "A804"
        InventoryProduct(1).DescriptionString = "College Logo Tshirt"
        InventoryProduct(1).QuantityInteger = 15
        InventoryProduct(1).PriceDecimal = 18.99D
        InventoryProduct(2).ProductIDString = "C344"
        InventoryProduct(2).DescriptionString = "College Logo Sweat Pants"
        InventoryProduct(2).QuantityInteger = 25
        InventoryProduct(2).PriceDecimal = 25.99D
        InventoryProduct(3).ProductIDString = "F554"
        InventoryProduct(3).DescriptionString = "Drinking Mug"
        InventoryProduct(3).QuantityInteger = 8
        InventoryProduct(3).PriceDecimal = 5.49D
        InventoryProduct(4).ProductIDString = "G302"
        InventoryProduct(4).DescriptionString = "Pencil and Pen Set"
        InventoryProduct(4).QuantityInteger = 15
        InventoryProduct(4).PriceDecimal = 35.5D
        InventoryProduct(5).ProductIDString = "M302"
        InventoryProduct(5).DescriptionString = "College Logo Sweat Shirt"
        InventoryProduct(5).QuantityInteger = 25
        InventoryProduct(5).PriceDecimal = 22.99D
        InventoryProduct(6).ProductIDString = "S499"
        InventoryProduct(6).DescriptionString = "Intro to Philosophy 
Textbook"
        InventoryProduct(6).QuantityInteger = 50
        InventoryProduct(6).PriceDecimal = 85D
        InventoryProduct(7).ProductIDString = "X599"
        InventoryProduct(7).DescriptionString = "Intro to CMIS Textbook"
        InventoryProduct(7).QuantityInteger = 75
        InventoryProduct(7).PriceDecimal = 79.4D



    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        'Search the ProductIDString property of the inventoryProduct array to see if the value of ProductIDTextBox matches an ID in the array Start variables to control the search

        Dim FoundBoolean As Boolean = False
        Dim RowInteger As Integer = 0

        'Loop through the array to control the search
        Do Until FoundBoolean = True Or RowInteger > NumberProductInteger
            'Compare TextBox to array
            If ProductIDTextBox.Text = InventoryProduct(RowInteger).ProductIDString Then
                'Found a match 
                DescriptionTextBox.Text = InventoryProduct(RowInteger).DescriptionString
                QuantityTextBox.Text = InventoryProduct(RowInteger).QuantityInteger
                PriceTextBox.Text = InventoryProduct(RowInteger).PriceDecimal

                'update the found variable to true
                FoundBoolean = True
            Else
                'no match found
                RowInteger += 1
            End If
        Loop

        'After the search determine if the ProductID was found
        If FoundBoolean = False Then
            'no match found
            DescriptionTextBox.Clear()
            QuantityTextBox.Clear()
            PriceTextBox.Clear()

            MessageBox.Show("Re-enter a valid Product ID!", "Invalid Product ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            ProductIDTextBox.Focus()
            ProductIDTextBox.SelectAll()
        End If
    End Sub

    Private Sub PurchaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseToolStripMenuItem.Click
        'Test to determine if a product was found.
        If DescriptionTextBox.Text = String.Empty Then
            'Cannot purchase coz the product was not found
            MessageBox.Show("You must select a valid product before purchasing", "Cannot Purchase Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ProductIDTextBox.Focus()
            ProductIDTextBox.SelectAll()
        Else
            'Can Purchase the product
            Dim ProductString As String = ProductIDTextBox.Text & " - " &
                DescriptionTextBox.Text & " - " & PriceTextBox.Text

            'Add the product to the purchase listbox
            PurchaseListBox.Items.Add(ProductString)

            'Display the total to the output textbox (TotalDueTextBox)
            TotalDueDecimal += Decimal.Parse(PriceTextBox.Text, Globalization.NumberStyles.Currency)
            TotalDueTextBox.Text = TotalDueDecimal.ToString("C")

            ProductIDTextBox.Clear()
            DescriptionTextBox.Clear()
            QuantityTextBox.Clear()
            PriceTextBox.Clear()

            ProductIDTextBox.Focus()
        End If
    End Sub

    Private Sub ResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem.Click
        'Clear all text box controls
        ProductIDTextBox.Clear()
        DescriptionTextBox.Clear()
        PriceTextBox.Clear()
        QuantityTextBox.Clear()
        TotalDueTextBox.Clear()

        'Clear the list box control
        PurchaseListBox.Items.Clear()

        'Reset the total due module-level variable to zero
        TotalDueDecimal = 0

        'Set the focus to the product ID text box
        ProductIDTextBox.Focus()

    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click
        SearchButton.PerformClick()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click

        Dim MessageString As String = "Version 1 of the BookStore Project" & ControlChars.NewLine & "Today's Date: " & Date.Now

        Dim TitleString As String = "About KCAU Bookstore Version 1 Application"

        MessageBox.Show(MessageString, TitleString, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class

   M S B A M L   `   `   `  ����   CurrencyCalculatorProg'    !CurrencyCalculatorProg.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  
MainWindow��$	��395��$	��525��.��� $	��578��.+��� -   $��image1��$��33��$
��Left=�$��	25,12,0,0q�$
��Fill=�$	��Top=�$��40���� -   $��currencyCB1��$��22��$
��Left=�$��	82,70,0,0q�$	��Top=�$	��106���� -   $��currencyCB2��$��22��$
��Left=�$��
299,70,0,0q�$	��Top=�$	��106���� -   $��switchButton��$��Switch��$��24��$
��Left=�$��
208,68,0,0q�$	��Top=�$��43���� -   $��
calcButton��$��	Calculate��$��24��$
��Left=�$��
421,68,0,0q�$	��Top=�$��59���� -   $��label1��$��From:��$��28��$
��Left=�$��	25,68,0,0q�$	��Top=�$��51���� -   $��label2��$	��To:��$��28��$��Right=�$��
0,68,285,0q�$	��Top=�$��26���� -   $��amountTextBlock��$��19��$
��Left=�$��
221,36,0,0q�$	��1.0��$	��Top=�$��43�� �� TextAlignment$ Center=��� -	   $��label3��$��Amount:��$��28��$
��Left=�$��
165,31,0,0q�$	��Top=�$��51���� -
   $��validationTextBlock��$��23��$
��Left=�$��
66,139,0,0q�$�� ��$	��Top=�$	��395��$
��Bold"�
���  ���� -   $��resultTextBlock��$��20��$
��Left=�$��209,110,0,0q�$�� ��$	��Top=�$��47��$
��Bold"� �� TextAlignment$ Center=��� -   $��label4��$��Result:��$��28��$
��Left=�$��165,105,0,0q�$	��Top=�$��51���� -   $��
ShowButton��$��Show Currencies��$��23��$
��Left=�$��
63,168,0,0q�$	��Top=�$	��102��&   System.Windows.Controls.DataGrid  -   $��currenciesDataGrid��$��Center=�   AutoGenerateColumns .     CanUserReorderColumns . $
��Auto��   AlternatingRowBackground
 ����� �� AlternationCount$ 2��$
��Left=�$��
36,197,0,0q�$	��Top=�$	��454��$y�Visible=�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Country��	   
IsReadOnly	 . 
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 100    CellTemplate �� .R�]� .+��� $
��Left=�$��16��$��16��$��5,0,15,0q����� *
IconPath+�� $
��Left=����� *	Country+0  *System.Windows.Controls.DataGridTextColumn  $
 Name��	 . $
 60 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+  $ Currency Code��	 . $	
 100  �� *CurrencyCode+  $
 Rate��	 . $
 60  �� *Rate+  $
 Unit��	 . $
 60  �� *Unit+  $ Change��	 . $
 60  �� *Change+
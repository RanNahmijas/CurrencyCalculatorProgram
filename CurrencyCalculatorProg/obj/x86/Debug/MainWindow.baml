   M S B A M L   `   `   `  ����  CurrencyCalculatorProg/    )Shenkar.CurrencyCalculatorProg.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F     � 
ResizeMode$  CanMinimize=�5   	    � WindowState$ Normal=�5   	    � WindowStyle$ ThreeDBorderWindow=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Currency Calculator��5	   	   $	��608��6%   $	��600��62   ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    � MappingMode$ RelativeToBoundingBox=�63    �� 
StartPoint$ 0.0,0&�6W   .��5      �  � Color$ 	#FFADC9E6��6   	 � Offset$	 1Q�61   5      .��5      � $��0,0,2,0q�6   .+�5   
   �� -   5        
 ��Name$

 Logo��5   U   $��91��6   $��Images/SmallLogo.jpg��6   $
��Left=�6:   $
��Fill=�6c   $	��Top=�6r   $	��104��6�   �� 5   
   $
��From��6   $
��Left=�6!   $��
109,20,0,0q�6<   $	��Top=�6P   $��60��6h   $	��155��6t    J� RenderTransformOrigin$ 0.487,0.509&�6�   $��15(�6�   $��Normal$�6�   .��5      �� -   5         ��Name$ FromComboBox��5      $��Center=�6-   $��Center=�6O   $
��Left=�6t   $	��140��6�   $��0,0,0,4q�6�   5      �� 5   
   $��To��6   $
��Left=�6   $��
346,20,0,0q�6:   $	��Top=�6N   $	��155��6f   $��60��6r   $��15(�6   $��Normal$�6�   .��5      �� -   5        $ 
ToComboBox��5      $
��Left=�6+   $��0,0,0,4q�6F   $ 0.5,0.5&�6W   $��Center=�6w   $��Center=�6�    J� 	AllowDrop .  $	��140��6�   $��30��6�   $��Bottom=�6�   5      �� 5   
   -   5         ��Name$ SwitchButton��5   ]   $��Switch��6   $��24��6"   $
��Left=�6.   $��
279,44,0,0q�6I   $	��Top=�6s   $��48��6�   $��11(�6�   $
��Bold"�6�   �� 5   
   -   5        $ 
CalcButton��5   a   $��	Calculate��6   $��24��6%   $
��Left=�61   $��274,120,0,0q�6L   $	��Top=�6u   $��62��6�   $��11(�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ ValidationTextBox��5   P   $��23��6   $
��Left=�6    $��109,172,0,0q�6;   $�� ��6k   $	��Top=�6s   $	��406��6�   $
��Bold"�6�   
���  ��$��15(�6�    �� TextAlignment$ Center=�6�   �� 5    
   $��Amount��6   $
��Left=�6#   $��60��6>   $��
104,94,0,0q�6J   $	��Top=�6^   $	��160��6v   $��0��6�   $��15(�6�   $��Normal$�6�   .��5!      �� -   5         ��Name$ AmountTextBox��5!      $
��Left=�6-   $��38��6H    �� TextWrapping$
 Wrap=�6T   $��Bottom=�6h    �� AutoWordSelection . $��20(�5$   	   $��SemiBold"�6   $��Normal$�6-    �� TextAlignment$ Center=�6@   {�.  $��0q�6i   $��0,0,-2,0q�6}   $��0,5,0,0q�6�   $	��150��6�   ��5"       �� *Input+ �� NotifyOnValidationError .  �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . 5$   �   5%      �� 5&   
   $��Result��6   $
��Left=�6#   $��60��6>   $	��Top=�6J   $	��160��6b   $��
346,94,0,0q�6n   $��15(�6�   $��Normal$�6�   .��5'      �� -   5        $ ResultTextBox��5'      $
��Left=�6/   $��38��6J   $
��Wrap=�6V   $	��Top=�6k   $	��150��6�   $��20(�6�   $��SemiBold"�6�   $��Normal$�6�   $ Center=�6�   $
��Auto=�5(   *   $
��Auto=�6\   ��. $��0,0,-2,0q�6�    � ContextMenu 5)      �� 5*      5,      5-      �� 5/   
   -	   5        $ 
ShowButton��5/   f   $��Show Currencies��6   $��23��6+   $
��Left=�67   $��
73,200,0,0q�6R   $	��Top=�6z   $	��102��6�   $��11(�6�   $
��Bold"�6�   �� 50   
   -
   5        $ RefreshButton��50   j   $��Refresh Currencies��6   $��23��6.   $
��Left=�6:   $��412,200,0,0q�6U   $	��Top=�6�   $	��115��6�   $��11(�6�   $
��Bold"�6�   &   System.Windows.Controls.DataGrid  52   
   -   5          Name$ CurrenciesDataGrid��52   �      AutoGenerateColumns .     CanUserReorderColumns . $
��Auto��6L      AlternatingRowBackground
 ����� �� AlternationCount$ 2��6�   $
��Left=�6�   $��
73,228,0,0q�6�   $	��Top=�6�   $	��454��6�   $y�	Collapsed=�6     Columns 53      4  .System.Windows.Controls.DataGridTemplateColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$ Country��6)       
IsReadOnly  . !   Width5  /System.Windows.Controls.DataGridLengthConverter$	! 100 6L   "   CellTemplate" 55      �� 56      .R�57      ]� .+�58   "   �� $
��Left=�6D   $��16��6Z   $��16��6e   $��5,0,15,0q�6q   ��6(   �� *
IconPath+6q   �� 59   "   $
��Left=�6E   ��6,   �� *	Country+6E   5:      5;      5=      0  *System.Windows.Controls.DataGridTextColumn  5>      $
 Name��6%     . $! 60 6E   1  +System.Windows.Controls.DataGridBoundColumn#   Binding# 6P   �� *Name+  5?      $ Currency Code��6%     . $	! 100 6N   # 6Z   �� *CurrencyCode+  5@      $
 Rate��6%     . $! 60 6E   # 6P   �� *Rate+  5A      $
 Unit��6%     . $! 60 6E   # 6P   �� *Unit+$ �� Mode$$ TwoWay=�% �� NotifyOnTargetUpdated% . & �� NotifyOnSourceUpdated& . $ PropertyChanged=�  5B      $ Change��6%     . $! 60 6G   # 6R   �� *Change+5D      5F      5G      
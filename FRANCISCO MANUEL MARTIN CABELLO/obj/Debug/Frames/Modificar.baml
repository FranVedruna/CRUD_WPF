   M S B A M L   `   `   `  ����Z  VFRANCISCO MANUEL MARTIN CABELLO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:FRANCISCO_MANUEL_MARTIN_CABELLO.Frames&FRANCISCO_MANUEL_MARTIN_CABELLO.Frames  5      6    0FRANCISCO_MANUEL_MARTIN_CABELLO.Frames.Modificar   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Flocal4clr-namespace:FRANCISCO_MANUEL_MARTIN_CABELLO.Frames     5        N� Title$  	Modificar��5	      .��5      �� ���#242424.+�5   
   � $��200px��6   $
��Left=�6   $��0,0,0,26q�68    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��0��6   $��26��6$   $��31��6/   $��/Media/ModificarVerde.png��6;   $��	64,0,10,0q�6^   �� 5      $��1��6      
CustomText#��[  6(   $	��Top=�6L   $��0,10,0,0q�6d   �� 6x   $�	MODIFICAR��6|   6�   5      �� 5   
   $��
100,20,0,0q�6   .+�5      �  5      �� 5      6)   �� 5      6)    � RowDefinitions 5      �� 5      6&   �� 5      6&   .+�5      �� #��[  6   $��Producto Antiguo��6@   $��0��6X   $��0��6h   6w   �� 5       -   5         ��Name$ 
OldProduct��5       $
��Left=�6.   $��20��6I   $	��300��6U   $��0��6a   $��1��6q   
�������$��0,0,0,1q�5!   _   ���	#FF777777$��0,10,0,0q�5"   .   ��5!      �� *
Background+ �� ElementName$ window��5"   .   �� 5#      #��[  6   $��Producto Nuevo��6@   $��1��6V   $��0��6f   6v   �� 5$      -   5        $ 
NewProduct��5$      $
��Left=�6.   $��20��6I   $	��300��6U   $��1��6a   $��1��6q   
�������$��0,0,0,1q�5%   ^   ���	#FF777777$��0,10,0,0q�5&   -   ��5%      �� *
Background+$ window��5&   -   5'      � 5)       5*      �� 5+      6)   �� 5,      6)   .+�5.      �� $��0��6   $��0,20,0,0q�6-   .+�5/      �� #��[  6    $��
Categoría��6D   6W   �� 50      -   5         ��Name$ CategoryComboBox��50      $��0,20,0,0q�69   51      �� 52      -   5        $��1��52      $	��120��6)   $��25��65   $��Bottom=�6A   .��6u   	Modificar6�   53      55      &   System.Windows.Controls.DataGrid  56   
   -   5          Name$ ProductosDataGrid��56         AutoGenerateColumns .     HeadersVisibility$ Column=�58      
������ $	��300��5:      $��10,40,10,10q�5;      ���#5DB85B	   GridLinesVisibility$		 All=�5=      
   Columns
 5?      0  *System.Windows.Controls.DataGridTextColumn  5@      ,  &System.Windows.Controls.DataGridColumn   Header$ Producto��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Nombre+6R     5A      $ 
Categoría��6%   $ * 6V    68   �� *	Categoria+6V   5C      5D      5E      
   M S B A M L   `   `   `  ����Z  VFRANCISCO MANUEL MARTIN CABELLO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:FRANCISCO_MANUEL_MARTIN_CABELLO.Frames&FRANCISCO_MANUEL_MARTIN_CABELLO.Frames  5      3    -FRANCISCO_MANUEL_MARTIN_CABELLO.Frames.Borrar   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Flocal4clr-namespace:FRANCISCO_MANUEL_MARTIN_CABELLO.Frames     5        N� Title$  Borrar��5	      .��5      �� ���#242424.+�5   
   � $��200px��6   $
��Left=�6   $��0,0,0,26q�68    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��0��6   $��26��6$   $��31��6/   $��/Media/BorrarVerde.png��6;   $��	64,0,10,0q�6[   �� 5      $��1��6      
CustomText#��[  6(   $	��Top=�6L   $��0,10,0,0q�6d   �� 6x   $�BORRAR��6|   6�   5      �� 5   
   $��
100,20,0,0q�6   .+�5      �  5      �� 5      6)   �� 5      6)   .+�5      �� $��0��6   $��0,20,0,0q�6-   .+�5      �� #��[  6    $��Producto��6D   $��0��6T   6f   �� 5       -   5         ��Name$ 
OldProduct��5       $
��Left=�62   $��20��6M   $	��300��6Y   $��0��6e   
�������$��0,0,0,1q�5!   _   ���	#FF777777$��0,10,0,0q�5"   .   ��5!      �� *
Background+ �� ElementName$ window��5"   .   5#      �� 5$      -   5        $��1��5$      $	��120��6)   $��25��65   $��Bottom=�6A   .��6u   Borrar6}   5%      5'      &   System.Windows.Controls.DataGrid  5(   
   -   5          Name$ ProductosDataGrid��5(         AutoGenerateColumns .     HeadersVisibility$ Column=�5*      
������ $	��375��5,      $��10,40,10,10q�5-      ���#5DB85B   GridLinesVisibility$	 All=�5/         Columns 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Producto��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Nombre+6R     53      $	 
Categoría��6%   $
 * 6V    68   �� *	Categoria+6V   55      56      57      
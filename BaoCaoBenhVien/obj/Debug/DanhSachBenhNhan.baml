   M S B A M L   `   `   `  ����I  EBaoCaoBenhVien, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BaoCaoBenhVienBaoCaoBenhVien  5   	   %    BaoCaoBenhVien.DanhSachBenhNhan   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:BaoCaoBenhVien     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   
   -   5           MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       
 ListVM � DataContext# [ 5       � WindowStartupLocation$ CenterScreen=�5   	    � Cursor$	 Pen��5   	    � Title$ Danh sách bệnh nhân��5   	   $	��600��6%   $
��1000��62   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 6$   �� *LoadedWindow_Command+
   CommandParameter
 6M   ��  �� ElementName$ 
mainWinDow��6�   5      .��5      �  � RowDefinitions 5   
   �� 5      6   �� 5      $��2* �6   6*   .+�5!   
   � $��0��6    5"      �� 5#      6"   �� 5$      6"   �� 5%      6"    � 	Resources 5'       �� 
TargetType �� Property �� Value��%T   '��       �� 5(      " ��6   .�5)      ��  � ��$
 Bold"�64   5*      5+      .+�5,      ��  �� Orientation$ 
Horizontal=�6   .+�5-      �� -   5         ��Name$ RDO_Thongtin��5-   =   $
��Bold"�6    �� Padding$
 0 40q�6.   $��	100 0 0 0q�6S   Tìm kiếm bệnh nhân6z   5.      �� 5/      $��1��6   $ 
Horizontal=�6&   .+�50      �� $��	100 0 0 0q�6   .+�51      �� 0.Nhập số hồ sơ/ tên vợ / tên chồng6C   �� 52      $ 
Horizontal=�6!   .+�53      �� -   5         ��Name$ TB_thongtin��53   H   $	��150��6]   6k   54      55      �� 57      -   5         ��Name$ BTN_TIM��57      $��60��6@   $��20 0 0 0q�6K   .��6]   Tìm6b   59      �� 5:      $��10 0 0 0q�6   $��2��6+   $ 
Horizontal=�68   $��Center=�6Q   .+�5;      �� $��60��6   Tổng số:62   �� 5<      -   5        $ 	TB_Tongso��5<   .   $�� ��6   $	��150��6"   6g   �� 5=      $��10 0 0 0q�6   ��6+   �� *Lietke_Command+.��6N   
Liệt kê6W   5>      5?      &   System.Windows.Controls.DataGrid  5@   
   -   5          Name$ DataGrid_Main��5J      $��1��5@       �� SelectedIndex$ 0��5A         CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .     
IsReadOnly . ���#F5F6F6
���   �   	RowHeight$ 40Q�5I      $��Stretch=�5Q      $
��auto��5R      $
��auto��5S      $��Stretch=�5T       �� SelectedItem 5G      �� *SelectedItem+ �� Mode$ TwoWay=���5K      �� *InfoAccounts+ 5W      ��%T   '��       �� 5X      " ��6   .�5Y      ��  � ��
 �   �63   5[      5]         Columns 5^      4  .System.Windows.Controls.DataGridTemplateColumn  5_      ,  &System.Windows.Controls.DataGridColumn    Width5	  /System.Windows.Controls.DataGridLengthConverter$
  auto	 6)   !   CellTemplate! 5`      �� 5a      .R�5b      �� $ 
Horizontal=�6)   .+�5c   "   �� ��6,   �� *STT+6C   5d      5e      5g      0
  *System.Windows.Controls.DataGridTextColumn
  5i      "   Header$" Số hồ sơ��6%   #   MinWidth$# 50Q�6b   1  +System.Windows.Controls.DataGridBoundColumn$   Binding$ 67   �� *MY_INFO_ACCOUNT.SoHoSo+6b   
  5j      $" FM��6%   $# 50Q�6X   $ 61   �� *MY_INFO_ACCOUNT.FM+6X   
  5k      $" Họ tên vợ��6%   $# 50Q�6d   $ 68   �� *MY_INFO_ACCOUNT.Hotenvo+6d   
  5l      $" 	Năm sinh��6%   $# 50Q�6_   $ 67   �� *MY_INFO_ACCOUNT.NSV+6_   
  5n      $" M��6%   $# 50Q�6V   $ 60   �� *MY_INFO_ACCOUNT.M+6V   
  5o      $" Họ tên chồng��6%   $# 50Q�6j   $ 6;   �� *MY_INFO_ACCOUNT.Hotenchong+6j   
  5p      $" 	Năm sinh��6%   $# 50Q�6_   $ 67   �� *MY_INFO_ACCOUNT.NSC+6_   
  5q      $" Bác sĩ tư vấn��6%   $# 50Q�6m   $ 6<   �� *MY_INFO_ACCOUNT.BacSiTheoDoi+6m   5v      5y      5z      
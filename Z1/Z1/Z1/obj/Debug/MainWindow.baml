   M S B A M L   `   `   `  ����=  9Z1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Z1Z1  5   	       Z1.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:Z1     5   	   -   5          � Title$  
MainWindow��5   	    � SizeToContent$ WidthAndHeight=�6    � WindowStyle$
 None=�6;    � AllowsTransparency . 
������ $	��396��6�   .��5
      �� $	��550��6   $	��459��6   ��5   
   �� 5      .+�5   
   F� -   5        $��UIPath��5   6   ���	#FFCFCFF1$��2��6"   $��301.804��6D    �� Stretch$
 Fill=�6U   $��514.222��6d    �� Left$ 18.489��6t    J� RenderTransformOrigin$ 0.5,0.5&�6�   
 �� Top$ 28.046��6�   ��5      �� 5       �� Color$ 	#FFE2E9FF��6"   ��5      B� 5      .��5      E� 	 E� 
StartPoint$		 0,0&�6!   .��5      �� 
 �� Point$
 0,375&�6&   �� 5      $
 50,450&�6&   �� 5      $
 650,450&�6&   �� 5      $
 650,75&�6&   �� 5      $
 550,0&�6&   �� 5      $	
 0,0&�6&   5      5      5      &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ dataGrid��5!         
IsReadOnly .    AutoGenerateColumns .  $ 0.5,0.5&�6v   $ 32��6�   $ 95��6�   $	��434��6�   $	��183��6�      CanUserResizeColumns .     CanUserAddRows .     CanUserReorderColumns .     CanUserResizeRows .  ��6%   �� *
Francuskas+   Columns 5#      4  .System.Windows.Controls.DataGridTemplateColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ Slika��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 68      CellTemplate 5%      �� 5&      .R�5'      �� $	��img��6$   ��6/   �� *PutanjaSlika+5(      5*      0  *System.Windows.Controls.DataGridTextColumn  5+      $ Znamenitosti��6%   $ * 6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *Znamenitosti+  5,      $ Ulaznica��6%   $ * 67    6B   �� *
Ulaznica+  5-      $ Datum��6%   $ * 64    6>   �� *DatumObilaska+  5.      $ Opcije��6)   $ * 69    5/      �� 50      .R�51      �� $��Center=�6)    �� Orientation$ Vertical=�6D   .+�52   "   �� $��Procitaj��6)   -   5        $��Procitaj��52   :   6M   �� 53   "   $��Izmijeni��6)   -   5        $��Izmijeni��53   :   6M   �� 54   "   $��Obrisi��6)   -   5        $��Obrisi��54   7   6H   55      56      58      5:      �� 5=   
   -   5        $��	francuska��5=   $   $��	franc.jpg��6   $
��Fill=�66   $��53��6E   $	��425��6Q   $ 22��6]   $ 28��6n   �� 5>   
   -   5        $��X��5>      $	 469��6   $ 55��6/   $��30��6?   $��26��6_   ���	#FF0C297C���	#FF0015AE J� Opacity$	 0.9Q�6�   $
��Bold"�6�   ���	#FFB5C3EA$��
Wide Latin)�6�   $ 
-0.071,0.6&�6�   5@      �� 5A   
   -	   5        $0��*Dodajte znamenitosti koje zelite posjetiti��5A      $	 127��6F   $	 293��6X   $	��275��6i   ���	#FFB5C3EA$��Italic$�6�   ���	#FF0015AE$��Perpetua)�6�   ���	#FF0C297C$
��Bold"�6�   6�   5D      5F      
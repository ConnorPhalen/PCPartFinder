   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fD2clr-namespace:MahApps.Metro;assembly=MahApps.MetroMahApps.Metro  5   	   D @PCfinder2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PCfinder2	PCfinder2 5	   	      PCfinder2.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;Controls,http://metro.mahapps.com/winfx/xaml/controls   5   	   ;
Converters*http://metro.mahapps.com/winfx/xaml/shared   5   	   >metro2clr-namespace:MahApps.Metro;assembly=MahApps.Metro   5   	   #localclr-namespace:PCfinder2   5	   	     �� ClearTypeHint$  Enabled=�5   	    � 
ResizeMode$ CanResizeWithGrip=�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   $	��400��5   	   $	��200��5   	   (   "MahApps.Metro.Controls.MetroWindow   ShowTitleBar .  � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������  � 	Resources 5       �� 
TargetType	 �� Property
 �� Value �� 
TargetType �� CornerRadius F�Name �� Stretch   AccentColorBrush ��Name �� Triggers P� Property P� Value �� 
TargetName  MyStackPanel �� ElementName �� Path��%"  '��       &	 ,    �� 5   
   " ��6   .�5      �� 	 � ��
 �#3747376+   �� 5      	 � ��

 �����6+   �� 5      	 � ��$
 15(�6)   �� 5      	 � ��$
 ./#Segoe UI)�6+   �� 5      	 �@J�SnapsToDevicePixels
 . 64   �� 5      	 � ��
 5       �� 5!      " ��6&   .R�5"      �� $ 4��6!   #��z��62   ._�5#      � .+�5$   "   F� $ PathIcon��6'   $��15��69   $��25��6D   $
 Fill=�6P   #���   6_   $
��Left=�6�   $��3,0,0,0q�6�   a�����������@�����р,���hx���рJ]���� �� ��� ��hx�@���р�7�hx�@ɢ ��	6�   �� 5%   "   $ MyContentPresenter��63   #��z��6O   $��Center=�6s   $��Center=�6�   $��0,0,0,0q�6�   5&      5'       5)      P� 5*       �@J�IsMouseOver . . �5+   "   �� 	 � ��
 �#E594F06?   �� 5,   "   	 � ��

 �����6?   �� 5-   "   $ PathIcon��6)   	 � ��

 �   �6O   5.      P� 50       � �� . . �51   "   �� 	 � ��

 � E��6?   �� 52   "   	 � ��

 �����6?   53      55      57      58      �� 5:   
   .+�5;      �� $��MainContent��6   $��	Watch Now��6+   $��20(�6<   �� 5<      $��DurationValue��6   $��12(�6q   
���������6-   �� $ MyWindow��$ (local:CurrentDuration)�6   5=      5>      .��5?      ��   AccentColorBrush4#���  6   
���   �$ 40,40,40,40��6R    �� Padding$ 6q�6m   ._�5@   
   � .+�5A      �� -   5         ��Name$ 
tabControl��5A      $
��auto��6Q   $��10,85,10,10q�6_   $��Stretch=�6t    �� SelectedIndex 6-   �� *	TabNumber+.@�5B      �� -   5         ��Name$ tabHome��5B      $
��Home��6+    �� 
IsSelected . $��Stretch=�6K   $
��auto��6i   $��0q�6w   $��Stretch=�6�   $
��auto��6�   ���	#CCFFFFFF.��5C      � 
�������$��0,-4,0,3q�6.   5D      5E      �� 5F      -   5         ��Name$ textBoxSearch��5F      $��Stretch=�6-   $��22��6K   $��211,33,187,0q�6W    �� TextWrapping$
 Wrap=�6m   $	��Top=�6�   $	��358��6�   6�   �� 5G      -   5         ��Name$ buttonSearch��5G      $��Search��6+   $��Right=�6<   $��	0,34,78,0q�6X   $	��Top=�6k   $	��104��6�   �� 5H      $��Center=�6   $��Center=�66   5J      �� 5K      -   5         ��Name$ 	imageLogo��5K      $��96��6'   $��28,0,0,0q�63   $	��Top=�6E   $$��Resources/PcPartFinderLogo.png��6]   $
��Left=�6�   $��77��6�   �� 5L      -   5         ��Name$ 	textBlock��5L      $��
132,10,0,0q�6+   $
��Wrap=�6?   $��PC Part Finder��6S     � Cursor$
  None��6i   $��
Lucida Fax)�6w   $��26.667(�6�   $	��101��6�   $	��Top=�6�   $
��Left=�6�   $��96��6�   ��6�   Z� 6�   5M      5N      !   RightWindowCommands! 5O      +   %MahApps.Metro.Controls.WindowCommands  5P   
   .@�5Q      �� -   5        .��5R      �� " �� Orientation$" 
Horizontal=�6   .+�5T      �� $��4 0 0 0q�6    $��Center=�5U       $��Change App Style...��5V       5W      5X      �� 5Y      -   5        .��5Z      �� $" 
Horizontal=�6   .+�5\      �� $��4 0 0 0q�6    $��Center=�5]       $��WishList��5^       5_      5`      5a      #   TitleTemplate# 5d      �� 5e   
   .R�5f      �� $��8 -1 0 0q�6   $��Center=�5g        DefaultFont#���  5h        WindowTitleFontSize#���  5i      $��CharacterEllipsis=�5k      ��5j      �� $ �� RelativeSource$ �� *TemplatedParent+$ Content�% �� 	Converter% /   )MahApps.Metro.Converters.ToUpperConverter  5k      5l      5q      
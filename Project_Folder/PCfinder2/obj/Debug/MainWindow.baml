   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fD2clr-namespace:MahApps.Metro;assembly=MahApps.MetroMahApps.Metro  5   	   D @PCfinder2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PCfinder2	PCfinder2 5	   	      PCfinder2.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;Controls,http://metro.mahapps.com/winfx/xaml/controls   5   	   ;
Converters*http://metro.mahapps.com/winfx/xaml/shared   5   	   >metro2clr-namespace:MahApps.Metro;assembly=MahApps.Metro   5   	   #localclr-namespace:PCfinder2   5	   	     �� ClearTypeHint$  Enabled=�5   	    � 
ResizeMode$ CanResizeWithGrip=�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   (   "MahApps.Metro.Controls.MetroWindow   ShowTitleBar .  � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������  � 	Resources 5       �� 
TargetType	 �� Property
 �� Value �� 
TargetType �� CornerRadius F�Name �� Stretch   AccentColorBrush ��Name �� Triggers P� Property P� Value �� 
TargetName  MyStackPanel �� ElementName �� Path��%"  '��       &	 ,    �� 5   
   " ��6   .�5      �� 	 � ��
 �#3747376+   �� 5      	 � ��

 �����6+   �� 5      	 � ��$
 15(�6)   �� 5      	 � ��$
 ./#Segoe UI)�6+   �� 5      	 �@J�SnapsToDevicePixels
 . 64   �� 5      	 � ��
 5      �� 5      " ��6&   .R�5       �� $ 4��6!   #��z��62   ._�5!      � .+�5"   "   F� $ PathIcon��6'   $��15��69   $��25��6D   $
 Fill=�6P   #���   6_   $
��Left=�6�   $��3,0,0,0q�6�   a�����������@�����р,���hx���рJ]���� �� ��� ��hx�@���р�7�hx�@ɢ ��	6�   �� 5#   "   $ MyContentPresenter��63   #��z��6O   $��Center=�6s   $��Center=�6�   $��0,0,0,0q�6�   5$      5%       5'      P� 5(       �@J�IsMouseOver . . �5)   "   �� 	 � ��
 �#E594F06?   �� 5*   "   	 � ��

 �����6?   �� 5+   "   $ PathIcon��6)   	 � ��

 �   �6O   5,      P� 5.       � �� . . �5/   "   �� 	 � ��

 � E��6?   �� 50   "   	 � ��

 �����6?   51      53      55      56      �� 58   
   .+�59      �� $��MainContent��6   $��	Watch Now��6+   $��20(�6<   �� 5:      $��DurationValue��6   $��12(�6q   
���������6-   �� $ MyWindow��$ (local:CurrentDuration)�6   5;      5<      .��5=      �� 
�������
���   �$ 40,40,40,40��68    �� Padding$ 6q�6S   ._�5>   
   � .+�5?      �� -   5         ��Name$ 
tabControl��5?      $��Stretch=�6Q   $
��auto��6o   $��10,85,10,10q�6}   $��Stretch=�6�   $
��auto��6�    �� SelectedIndex 6-   �� *	TabNumber+.@�5@      �� -   5         ��Name$ tabHome��5@      $
��Home��6+    �� 
IsSelected . $��Stretch=�6K   $
��auto��6i   $��0q�6w   $��Stretch=�6�   $
��auto��6�   ���	#CCFFFFFF.��5A      � 
�������$��
0,-4,0,3.5q�6.   5B      5C      �� 5D      -   5         ��Name$ textBoxSearch��5D      $��Stretch=�6-   $��22��6K   $��211,33,187,0q�6W    �� TextWrapping$
 Wrap=�6m   $	��Top=�6�   $	��358��6�   6�   �� 5E      -   5         ��Name$ buttonSearch��5E      $��Search��6+   $��Right=�6<   $��	0,34,78,0q�6X   $	��Top=�6k   $	��104��6�   �� 5F      $��Center=�6   $��Center=�66   5H      �� 5I      -   5         ��Name$ 	imageLogo��5I      $��96��6'   $��28,0,0,0q�63   $	��Top=�6E   $$��Resources/PcPartFinderLogo.png��6]   $
��Left=�6�   $��77��6�   5J      5K         RightWindowCommands 5L      +   %MahApps.Metro.Controls.WindowCommands  5M   
   .@�5N      �� -   5        .��5O      ��   �� Orientation$  
Horizontal=�6   .+�5Q      �� $��4 0 0 0q�6    $��Center=�5R       $��Change App Style...��5S       5T      5U      5V      !   TitleTemplate! 5X      �� 5Y   
   .R�5Z      �� $��8 -1 0 0q�6   $��Center=�5[        DefaultFont#���  5\        WindowTitleFontSize#���  5]      $��CharacterEllipsis=�5_      ��5^      �� " �� RelativeSource" �� *TemplatedParent+$ Content�# �� 	Converter# /   )MahApps.Metro.Converters.ToUpperConverter  5_      5`      5e      
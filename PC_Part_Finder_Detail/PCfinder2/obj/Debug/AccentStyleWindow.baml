   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fD2clr-namespace:MahApps.Metro;assembly=MahApps.MetroMahApps.Metro  5       	PCfinder2!   PCfinder2.AccentStyleWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;Controls,http://metro.mahapps.com/winfx/xaml/controls   5      ;
Converters*http://metro.mahapps.com/winfx/xaml/shared   5      >metro2clr-namespace:MahApps.Metro;assembly=MahApps.Metro   5        �� ClearTypeHint$  Enabled=�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�5       � Title$ Change App Style��5	       � SizeToContent$ WidthAndHeight=�5
         AccentColorBrush(   "MahApps.Metro.Controls.MetroWindow   	GlowBrush# �   5       � 
ResizeMode$ CanResizeWithGrip=�5       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $M Gpack://application:,,,/MahApps.Metro;component/Styles/Accents/Blue.xaml?�6%   �� 5      $R Lpack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseLight.xaml?�6%   %    5      	   TitleTemplate	 5      �� 5   
   .R�5      �� $��CharacterEllipsis=�5      $��Center=�5      $��8 -1 0 0q�5        WindowTitleFontSize#���  5        DefaultFont#���  5      ��5      �� 
 �� RelativeSource
 �� *TemplatedParent+ �� Path$ Content� �� 	Converter /   )MahApps.Metro.Converters.ToUpperConverter  5      5       .��5#      �  5$   
    �� 
TargetType  MetroButton �� BasedOn �� Property �� Value��%�   '��       7  �� 5%      " ��6   8   .�5'      ��  � ��$ 23��5(      �� 5)       � ��$ 2q�5*      5+      5,       � RowDefinitions 5.   
   �� 5/      $
��Auto �6   �� 50      $
��Auto �6   .+�53   
   �� $��1��6   $��5q�54      $��Change Application��55      .��56      �  57      �� 58      $
��Auto �6$   �� 59      $
��Auto �6$   �� 5:      $
��Auto �6$   .+�5=      A� $��0��6    A� Columns$ 5��5>      .+�5?      �� -   5        $
��Dark��5?      5@      �� 5A      -   5        $��Light��5A      5B      �� 5C      -   5        $
��Blue��5C      5D      �� 5E      -   5        $	��Red��5E      5F      �� 5G      -   5        $��Green��5G      5H      5I      A� 5K      $��1��6   $ 5��5L      .+�5M      �� -   5        $��Custom Theme��5M      5N      �� 5O      -   5        $��Custom Accent 1��5O      5P      �� 5Q      -   5        $��Custom Accent 2��5Q      5R      5S      A� 5U      $��2��6   $��5q�6+   $ 2��66   .+�5W      �� -	   5         ��Name$ ColorsSelector��5W      $��5q�5X      ��5Z      �� *Colors+��5[      �� 5\      .R�5]   "   �� ��6,   �� *Key+5^      5`      5a      5b      5c      5e      5g      
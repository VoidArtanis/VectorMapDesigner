   M S B A M L   `   `   `  ����A  =Imagio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Imagio.GUI.ControlsImagio.GUI.Controls  5      3clr-namespace:Imagio.ConverterImagio.Converter  5      5clr-namespace:Imagio.PropertiesImagio.Properties  5	          Imagio.GUI.MeasureWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;controls,http://metro.mahapps.com/winfx/xaml/controls  5      1	controls1!clr-namespace:Imagio.GUI.Controls  5      .	converterclr-namespace:Imagio.Converter  5      0
Propertiesclr-namespace:Imagio.Properties  5	        � Title$  Measurer��5      $��492.414��6   $��783.567��6'   
���   � � 
ResizeMode$ NoResize=�6K    � WindowStartupLocation$ CenterScreen=�6a    � 	Resources 5      *   $Imagio.Converter.PercentageToDecimal   	converter��%   &	          5   
   6(   5      .��5      � -   5         �Name$
 Grid��5      .+�5   
   �  J� RenderTransformOrigin$ 0.5,0.5&�6   $��0,1,0,0q�6/   .+�5      � ���	#FF151515.+�5      $  Imagio.GUI.Controls.GridCanvas  -   5          Name$ 
GridCanvas��5   '   $
��Left=�5   +   $	��Top=�6F   }�. ��5   ;   �� *Text+ �� ElementName$ TxtMapWidth����5   +   �� *Text+$ TxtMapHeight�� � LayoutTransform 5      �� 5      -   5        GridCanvasScaleTransform��	 �� ScaleX	 5   -   �� *Text+
 �� 	Converter#
 [  $ 
TxtMapZoom�� �� ScaleY 5   -   �� *Text+#
 [  $ 
TxtMapZoom��5       �� 5!      $��0,82,4,0q�6    �� Orientation$ 
Horizontal=�6/   $	��Top=�6H   $��Center=�6`   .+�5"      �� -   5         ��Name$ txtDistance��5"       $
��Wrap=�65   $��0��6I   $	��122(�6R   ���	#FF00C146$��Center=�6x   �� 5#      -   5        $ textBlock1_Copy��5#       $
��Wrap=�69   $��mm��6M   $	��122(�6W   ���	#FF00C146$��Center=�6}   5$      �� 5%      $��265,247,265,151q�6   $ 
Horizontal=�66   $��Center=�6O   .+�5&      �� -   5         ��Name$ btnLeft��5&      $	����6.   $��0q�6A   $��icomoon)�6U   $��36(�6j   $��64��6x   $	��0,6q�6�   
�������$ 0.804,1.375&�6�   $��64��6�   ��6�   Z� 6�   �� 5'      -   5        $ 
textBlock2��5'       $
��Wrap=�64   $��ROTATE��6H   $��Center=�6V   $
��40,0q�6q   
�������6   �� 5(      -   5        $ btnRight��5(      $��0q�6/   $��icomoon)�6C   $��36(�6X   $��64��6f   $	��0,6q�6�   
�������$ 0.804,1.375&�6�   $��64��6�   $��0q�6�   $	����6�   ��6q   Z� 6�   5)      �� 5*      -	   5        $ buttonbtnMeasure��5*      $��Measure��63   $
��Left=�6E   $��44��6`   $��328,371,0,0q�6l   $	��Top=�6�   $	��122��6�   6�   �� 5+      $ 
Horizontal=�6   $��Center=�66   $��677,18,4,415q�6S   $��97��6i   .+�5,      �� -
   5        $ 
textBlock3��5,       $
��Wrap=�64   $��LASER��6H   $��Center=�6U   $
��Left=�5-      $��0,0,5,0q�5.      ���	#FFE0E0E06*   /  )MahApps.Metro.Controls.ToggleSwitchButton  5/      -   5          Name$ LaserToggle��5/   2   $
��WWQ3��6G   $��25��6V   $��42.667��6b   $��Center=�50      $��Right=�64   52   ;   53      54      56      �� 57   
   $��28��6   $��Bottom=�6   $��0,1,0,0q�68   ���	#FF999999$��1��6j   ._�58      � ���	#FF252525.+�59      �� $��Right=�6   $ 
Horizontal=�6:   $��72��6S   �� 5:      -   5        $ 	txtStatus��5:      $
��Wrap=�61   $��Ready��6E   $��Center=�6R   
�������$��11,6,0,5q�6�   $
��Left=�6�   $��75��6�   5<      5=      � 5>   
   -   5        $ 
GrdStartup��5>      $	��583��6#   $	��Top=�60   ���	#FF1D1D1D$��2��6a   .+�5?      � $��-79,144,-89,265q�6   $��Center=�6,   $��Center=�6G   $	��174��6d   $	��946��6q   .+�5@      �� -   5        $ 	textBlock��5@      $��Center=�6/   $
��Wrap=�6L   $	����6`   $	��Top=�6p   $��icomoon)�6�   $	��108(�6�   
�������6�   �� 5A      -   5        $ Status��5A      $��Center=�6,   $��	0,131,0,0q�6I   $
��Wrap=�6\   $��
Connecting��6p   $	��Top=�6�   ���	#FFFBFBFB$��18(�6�   � 5B      $��Center=�6   $	��Top=�6=   $	��163��6U   $��	0,165,0,0q�6a   $��9��6t    � IsIndeterminate . ���	#FF00151F6�   5D      5E      �� 5F   
   $��389,48.832,389,0q�6   $ Vertical=�6/   $��Center=�6F   $	��Top=�6c   $��1��6{   �� 5G   
   -   5         ��Name$ textBox��5G      $
��Left=�6#   $��23��6>   $��1049,236,-391,0q�6J    �� TextWrapping$
 Wrap=�6c   $��TextBox��6w   $	��Top=�6�   $	��120��6�   5H      5I      
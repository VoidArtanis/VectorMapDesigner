   M S B A M L   `   `   `  ����A  =Imagio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Imagio.GUI.ControlsImagio.GUI.Controls  5      3clr-namespace:Imagio.ConverterImagio.Converter  5          Imagio.GUI.CaptureWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;controls,http://metro.mahapps.com/winfx/xaml/controls  5      1	controls1!clr-namespace:Imagio.GUI.Controls  5      .	converterclr-namespace:Imagio.Converter  5        � Title$  Designer��5      $��611.629��6   $��962.391��6'   
���   � � 
ResizeMode$ NoResize=�6K    � WindowStartupLocation$ CenterScreen=�6a    � 	Resources 5      *   $Imagio.Converter.PercentageToDecimal   	converter��%   &	          5   
   6(   5      .��5      � -   5         �Name$
 Grid��5      .+�5   
   �  J� RenderTransformOrigin$ 0.5,0.5&�6   $��67,1,0,0q�6/   z�5      V� 5      .~�5      ��  �� ScaleX$ -1Q�6%   �� 5      �� 5      T� 5      5      .+�5      � .+�5      �� -   5         ��Name$ 	MapCanvas��5      }�. 
�������$��0,0,0,24q�5   5    � LayoutTransform 5       �� 5!      -   5        MapCanvasScaleTransform�� 5"   -   �� 	 �� ElementName$	 
TxtMapZoom��
 �� Path$

 Text� �� 	Converter# [   �� ScaleY 5#   -   �� $	 
TxtMapZoom��$

 Text�# [  5%      $  Imagio.GUI.Controls.GridCanvas  5&      -   5          Name$ 
GridCanvas��5&   '   $
��Left=�5(   +   $	��Top=�6F   }�. ��5&   ;   �� $	 TxtMapWidth��$

 Text���5'   +   �� $	 TxtMapHeight��$

 Text� 5)      �� 5*      -   5        GridCanvasScaleTransform�� 5+   -   �� $	 
TxtMapZoom��$

 Text�# [   5,   -   �� $	 
TxtMapZoom��$

 Text�# [  5.      5/      51      �� 52   
   $��28��6   $��Bottom=�6   $��0,1,0,0q�68   ���	#FF999999._�53      � ���	#FF252525.+�54      �� $��Right=�6    �� Orientation$ 
Horizontal=�6:   $��72��6S   .+�55      �� -   5         ��Name$ txtDistance��55       $
��Wrap=�67   $��0m��6K   $��Center=�6U   
�������6p   �� 56      -   5        $ 
txtDegrees��56       $
��Wrap=�66   $	��0°��6J   $��Center=�6T   
�������$��20,6,0,5q�6�   57      �� 58      -   5        $ 	txtStatus��58      $
��Wrap=�61   $��Ready��6E   $��Center=�6R   
�������$��11,6,0,5q�6�   $
��Left=�6�   $��75��6�   � 59      -	   5         �Name$
 prog��59      $
��Left=�6,   $��	114,8,0,9q�6G   $��Center=�6Z   $	��100��6u   5;      5<      �� 5=   
   $��0,0,0,28q�6   $
��Left=�6'   $��65��6B   
���   �.+�5?      �� -
   5         ��Name$ btnSmartFilter��5?      $	����6-   $��0,0,0,1q�6@   $��64��6w   $��64��6�   $
��Left=�6�   $	��Top=�6�   $��icomoon)�6�   $��24(�6�   $��0,16,0,0q�6  ��6�   Z� ��6�   Z� 6  5A      � 5B   
   -   5        $ 
GrdStartup��5B      $	��583��6#   $	��Top=�60   ���	#FF1D1D1D.+�5C      � $��10,216,0,193q�6   $��Center=�6)   $��Center=�6D   $	��174��6a   $	��946��6n   .+�5D      �� -   5        $ 	textBlock��5D      $��Center=�6/   $
��Wrap=�6L   $	����6`   $	��Top=�6p   $��icomoon)�6�   $	��108(�6�   
�������6�   �� 5E      -   5        $ Status��5E      $��Center=�6,   $��	0,131,0,0q�6I   $
��Wrap=�6\   $��
Connecting��6p   $	��Top=�6�   ���	#FFFBFBFB$��18(�6�   � 5F      $��Center=�6   $	��Top=�6=   $	��163��6U   $��	0,165,0,0q�6a   $��9��6t    � IsIndeterminate . ���	#FF00151F6�   5H      5I      �� 5J   
   $��429,374,429,0q�6   $ Vertical=�6,   $��Center=�6C   $	��Top=�6`   �� 5K   
   -   5        $ 	btnAccept��5K      $	����6$   $��0,0,0,1q�67   $��64��6i   $��64��6t   $
��Left=�6�   $	��Top=�6�   $��icomoon)�6�   $��48(�6�   $��	0,486,0,0q�5L      ��5K   �   Z� ��6�   Z� 5L      5N      5O      
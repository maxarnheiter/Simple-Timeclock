   M S B A M L   `   `   `  ����  SimpleTimeClock     SimpleTimeClock.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  Main_Window��5   	    � Title$ 
MainWindow��5   	   $	��637��6   $	��751��6)   .��5      � .+�5   
   �� -   5         ��Name$ out_listbox��5      $
��Left=�6'   $	��402��6B   $��	9,194,0,0q�6O   $	��Top=�6b   $	��256��6z   $��18(�6�   �� 5   
   -   5        $ 
in_listbox��5      $
��Left=�6&   $	��402��6A   $��475,193,0,0q�6N   $	��Top=�6c   $	��256��6{   $��18(�6�   �� 5   
   $	��Out��6   $��	9,153,0,0q�6   $	��Top=�61   $��41��6I   $��Center=�6U   ���	#FFF3F3F3$��1,1,1,0q�6�   ���	#FF828790$	��256��6�   $
��Left=�6�   $��22(�6�   �� 5	   
   $��In��6   $��475,152,0,0q�6   $	��Top=�62   $��41��6J   $	��256��6V   $��Center=�6b   ���	#FF828790$��1,1,1,0q�6�   ���	#FFF3F3F3$
��Left=�6�   $��22(�6�   �� 5
   
   -   5         ��Name$ current_time_label��5
      $��12:00:00��6,   $
��Left=�6?   $��Center=�6Z   $��
538,90,0,0q�6~   $	��Top=�6�    J� RenderTransformOrigin$ -0.658,0.423&�6�   $	��148��6�   $
��Bold"�6�   $��30��6�   $��18(�6�   �� 5   
   -   5        $ current_date_label��5      $��1/1/2010��6,   $
��Left=�6?   $��Center=�6Z   $��
538,56,0,0q�6~   $	��Top=�6�   $ -0.658,0.423&�6�   $	��148��6�   $��34��6�   $
��Bold"�6�   $��18(�6�   �� 5   
   $��	Company: ��6   $
��Left=�6$   $��6,74,0,0q�6?   $	��Top=�6Q   $	��180��6i   $ 2.078,-0.231&�6u   $��18(�6�   �� 5   
   -   5        $ company_name_label��5      $��NO COMPANY LOADED��6,   $
��Left=�6H   $��
100,74,0,0q�6c   $	��Top=�6w   $	��265��6�   $
��Bold"�6�   $��18(�6�   o� 5   
   $
��Left=�6   $��29��6*   $	��Top=�66   $	��743��6N   $��0,0,0,1q�6Z   ���	#FFBFBFBF��5      �� 5       �� EndPoint$	 0,1&�6&    �� 
StartPoint$	 0,0&�65   .��5      �  � Color$ 	#FFF3F3F3��6#   � 5      $ 	#FFF3F3F3��6#    � Offset$ 1Q�65   5      .@�5      m� $
��File��6   $��18(�6%   .@�5      m� -   5        	 m�Name$	 open_menu_item��5      $
��Load��63   6A   m� 5      -   5        $	 create_menu_item��5      $��
Create New��65   6I   m� 5      -	   5        $	 close_menu_item��5      $��Close��64   6C   5      m� 5      -
   5        $	 settings_menu_item��5      $��Settings��63   $��18(�6f   m� 5      -   5        $	 export_menu_item��5      $��Export��61   $��18(�6`   m� 5      -   5        $	 pto_menu_item��5      $	��PTO��6.   $��18(�6W   5      �� 5   
   -   5        
 ��Name$
 clock_in_image��5      $
��Left=�6(   $��56��6C   $��311,263,0,0q�6O   $	��Top=�6d   $	��119��6|   $��Images/clock_in_black.png��6�   $
��Fill=�6�    �� BitmapScalingMode$ HighQuality=�6�   $ 0.5,0.5&�6�   $y�Hidden=�6=  �� 5   
   -   5        $
 clock_out_image��5      $
��Left=�6)   $��56��6D   $��311,432,0,0q�6P   $	��Top=�6e   $	��119��6}   $ ��Images/clock_out_black.png��6�   $
��Fill=�6�   $ HighQuality=�6�   $ 0.5,0.5&�6�   $y�Hidden=�6@  �� 5    
   -   5        $
 clock_in_image_gray��5       $
��Left=�6-   $��56��6H   $��311,263,0,0q�6T   $	��Top=�6i   $	��119��6�   $��Images/clock_in_gray.png��6�   $
��Fill=�6�   $ HighQuality=�6�   $ 0.5,0.5&�6�   $y�Visible=�6A   K� ZIndex$ -1��6V  �� 5!   
   -   5        $
 clock_out_image_gray��5!      $
��Left=�6.   $��56��6I   $��311,432,0,0q�6U   $	��Top=�6j   $	��119��6�   $��Images/clock_out_gray.png��6�   $
��Fill=�6�   $ HighQuality=�6�   $ 0.5,0.5&�6�   $y�Visible=�6D  $ -1��6Y  �� 5"   
   ���	#FFF4F4F5$
��Left=�6%   $��69��6@   $��
538,56,0,0q�6L   
���   �$	��Top=�6o   $	��148��6�   $ -1��6�   5$      5%      
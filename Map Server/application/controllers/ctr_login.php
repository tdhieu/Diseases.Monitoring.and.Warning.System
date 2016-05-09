<?php if ( ! defined('BASEPATH')) exit('No direct script access allowed');

class ctr_login extends CI_Controller {

	/**
	 * Index Page for this controller.
	 *
	 * Maps to the following URL
	 * 		http://example.com/index.php/welcome
	 *	- or -  
	 * 		http://example.com/index.php/welcome/index
	 *	- or -
	 * Since this controller is set as the default controller in 
	 * config/routes.php, it's displayed at http://example.com/
	 *
	 * So any other public methods not prefixed with an underscore will
	 * map to /index.php/welcome/<method_name>
	 * @see http://codeigniter.com/user_guide/general/urls.html
	 */
	public function index()
	{
		$this->load->view('view_login');
	}
	function authorizeUser()
	{
	
		if($this->input->post('username')!=""){
			$username= $this->input->post('username');
			$password = $this->input->post('password');
			
			$username = stripslashes(trim($username));
			$password = stripslashes(trim($password));
			$password = sha1($password);
			
			$this->load->model("mdl_login");
			$row_count = $this->mdl_login->authorizeUser($username,$password);
			if($row_count > 0){
				redirect($this->config->item('base_url').'index.php/ctr_admin');
				//header('Location: '.$this->config->item('base_url').'index.php/ctr_admin');
			}
			else
			{
				redirect($this->config->item('base_url').'index.php/ctr_login');
				//header('Location: '.$this->config->item('base_url').'index.php/ctr_login');
			}
		}
		else
		{
			redirect($this->config->item('base_url').'index.php/ctr_login');
			//header('Location: '.$this->config->item('base_url').'index.php/ctr_login');
		}
	}
}

/* End of file welcome.php */
/* Location: ./application/controllers/welcome.php */
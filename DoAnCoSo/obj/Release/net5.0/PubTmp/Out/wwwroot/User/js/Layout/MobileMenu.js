const menuIconMobile3 = select('#evo-trigger-mobile3');
const menuIconMobile2 = select('#evo-trigger-mobile2');
const menuMobileSidebar = select('.mobile-main-menu');

const showMenuMobileSidebar = () => {
	menuMobileSidebar.classList.add('active');
	select('.backdrop__body-backdrop___1rvky').classList.add('active');
	const closeMenuMobileSidebar = select('.evo-close-menu');
	closeMenuMobileSidebar.addEventListener('click', function () {
		menuMobileSidebar.classList.remove('active');
		select('.backdrop__body-backdrop___1rvky').classList.remove('active');
	});

	select('.backdrop__body-backdrop___1rvky').addEventListener('click', function () {
		closeMenuMobileSidebar.click();
	});
}

menuIconMobile3.addEventListener('click', showMenuMobileSidebar);
menuIconMobile2.addEventListener('click', showMenuMobileSidebar);